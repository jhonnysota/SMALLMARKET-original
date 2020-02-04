namespace ClienteWinForm.Maestros
{
    partial class frmImportarAuxiliares
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
            this.lblCantidad = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.btProcesar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExaminar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btErrores = new System.Windows.Forms.Button();
            this.btIntegrar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCantidad.Location = new System.Drawing.Point(176, 129);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(0, 14);
            this.lblCantidad.TabIndex = 319;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(130, 107);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(40, 38);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 318;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.Transparent;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblProcesando.Location = new System.Drawing.Point(176, 109);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 14);
            this.lblProcesando.TabIndex = 317;
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
            this.btProcesar.Location = new System.Drawing.Point(538, 98);
            this.btProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(65, 47);
            this.btProcesar.TabIndex = 316;
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
            this.btActualizar.Location = new System.Drawing.Point(471, 98);
            this.btActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(65, 47);
            this.btActualizar.TabIndex = 315;
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
            this.panel1.Location = new System.Drawing.Point(129, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 62);
            this.panel1.TabIndex = 314;
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
            this.btExaminar.Location = new System.Drawing.Point(509, 27);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(81, 22);
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
            this.txtRuta.Size = new System.Drawing.Size(496, 21);
            this.txtRuta.TabIndex = 297;
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Image = global::ClienteWinForm.Properties.Resources.HojaExcel;
            this.pbImagen.Location = new System.Drawing.Point(4, 4);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(122, 142);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 313;
            this.pbImagen.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 365;
            this.label2.Text = "Tipo Auxiliar";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.DropDownWidth = 132;
            this.cboTipo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Clientes",
            "Proveedores"});
            this.cboTipo.Location = new System.Drawing.Point(199, 6);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(155, 21);
            this.cboTipo.TabIndex = 364;
            // 
            // btErrores
            // 
            this.btErrores.BackColor = System.Drawing.Color.Azure;
            this.btErrores.Enabled = false;
            this.btErrores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btErrores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btErrores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btErrores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btErrores.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btErrores.Image = global::ClienteWinForm.Properties.Resources.borrar_registro;
            this.btErrores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btErrores.Location = new System.Drawing.Point(605, 98);
            this.btErrores.Margin = new System.Windows.Forms.Padding(2);
            this.btErrores.Name = "btErrores";
            this.btErrores.Size = new System.Drawing.Size(63, 47);
            this.btErrores.TabIndex = 366;
            this.btErrores.Text = "Errores";
            this.btErrores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btErrores.UseVisualStyleBackColor = false;
            this.btErrores.Click += new System.EventHandler(this.btErrores_Click);
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
            this.btIntegrar.Location = new System.Drawing.Point(670, 98);
            this.btIntegrar.Margin = new System.Windows.Forms.Padding(2);
            this.btIntegrar.Name = "btIntegrar";
            this.btIntegrar.Size = new System.Drawing.Size(63, 47);
            this.btIntegrar.TabIndex = 367;
            this.btIntegrar.Text = "Integrar";
            this.btIntegrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btIntegrar.UseVisualStyleBackColor = false;
            this.btIntegrar.Click += new System.EventHandler(this.btIntegrar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.Azure;
            this.btCancelar.Enabled = false;
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(406, 98);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(63, 47);
            this.btCancelar.TabIndex = 368;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(602, 18);
            this.label8.TabIndex = 430;
            this.label8.Text = "Ruta del Archivo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmImportarAuxiliares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 150);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btIntegrar);
            this.Controls.Add(this.btErrores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.btProcesar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbImagen);
            this.Name = "frmImportarAuxiliares";
            this.Text = "Importa Auxiliares (Excel)";
            this.Load += new System.EventHandler(this.frmImportarClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Button btErrores;
        private System.Windows.Forms.Button btIntegrar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label8;
    }
}