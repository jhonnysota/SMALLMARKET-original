namespace ClienteWinForm.Contabilidad
{
    partial class frmImportarRegistroKardex
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
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.btProcesar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExaminar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btIntegrar = new System.Windows.Forms.Button();
            this.bterrores = new System.Windows.Forms.Button();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.chkUsarAlmacen = new System.Windows.Forms.CheckBox();
            this.chkUsarOperacion = new System.Windows.Forms.CheckBox();
            this.cboOperaciones = new System.Windows.Forms.ComboBox();
            this.rbOperaciones = new System.Windows.Forms.RadioButton();
            this.rbAlmacenes = new System.Windows.Forms.RadioButton();
            this.rbKardex = new System.Windows.Forms.RadioButton();
            this.cboAlmacenes = new System.Windows.Forms.ComboBox();
            this.btRevisarLotes = new System.Windows.Forms.Button();
            this.lblregistros = new System.Windows.Forms.Label();
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
            this.lblProcesando.Location = new System.Drawing.Point(235, 163);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 13);
            this.lblProcesando.TabIndex = 315;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(183, 145);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(47, 44);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 313;
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
            this.btProcesar.Location = new System.Drawing.Point(643, 143);
            this.btProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(65, 47);
            this.btProcesar.TabIndex = 312;
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
            this.btActualizar.Location = new System.Drawing.Point(574, 143);
            this.btActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(65, 47);
            this.btActualizar.TabIndex = 311;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblregistros);
            this.panel1.Controls.Add(this.btExaminar);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Location = new System.Drawing.Point(174, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 62);
            this.panel1.TabIndex = 310;
            // 
            // btExaminar
            // 
            this.btExaminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btExaminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExaminar.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExaminar.Location = new System.Drawing.Point(515, 28);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(80, 20);
            this.btExaminar.TabIndex = 295;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExaminar.UseVisualStyleBackColor = true;
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
            this.txtRuta.Size = new System.Drawing.Size(504, 21);
            this.txtRuta.TabIndex = 297;
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
            this.btIntegrar.Location = new System.Drawing.Point(781, 143);
            this.btIntegrar.Margin = new System.Windows.Forms.Padding(2);
            this.btIntegrar.Name = "btIntegrar";
            this.btIntegrar.Size = new System.Drawing.Size(65, 47);
            this.btIntegrar.TabIndex = 317;
            this.btIntegrar.Text = "Integrar";
            this.btIntegrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btIntegrar.UseVisualStyleBackColor = false;
            this.btIntegrar.Click += new System.EventHandler(this.btIntegrar_Click);
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
            this.bterrores.Location = new System.Drawing.Point(712, 143);
            this.bterrores.Margin = new System.Windows.Forms.Padding(2);
            this.bterrores.Name = "bterrores";
            this.bterrores.Size = new System.Drawing.Size(65, 47);
            this.bterrores.TabIndex = 316;
            this.bterrores.Text = "Errores";
            this.bterrores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bterrores.UseVisualStyleBackColor = false;
            this.bterrores.Click += new System.EventHandler(this.bterrores_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Image = global::ClienteWinForm.Properties.Resources.HojaExcel;
            this.pbImagen.Location = new System.Drawing.Point(3, 3);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(165, 190);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 309;
            this.pbImagen.TabStop = false;
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
            this.btCancelar.Location = new System.Drawing.Point(507, 143);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(63, 47);
            this.btCancelar.TabIndex = 318;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // chkUsarAlmacen
            // 
            this.chkUsarAlmacen.AutoSize = true;
            this.chkUsarAlmacen.Enabled = false;
            this.chkUsarAlmacen.Location = new System.Drawing.Point(178, 119);
            this.chkUsarAlmacen.Name = "chkUsarAlmacen";
            this.chkUsarAlmacen.Size = new System.Drawing.Size(92, 17);
            this.chkUsarAlmacen.TabIndex = 320;
            this.chkUsarAlmacen.Text = "Usar Almacén";
            this.chkUsarAlmacen.UseVisualStyleBackColor = true;
            this.chkUsarAlmacen.CheckedChanged += new System.EventHandler(this.chkUsarAlmacen_CheckedChanged);
            // 
            // chkUsarOperacion
            // 
            this.chkUsarOperacion.AutoSize = true;
            this.chkUsarOperacion.Enabled = false;
            this.chkUsarOperacion.Location = new System.Drawing.Point(178, 96);
            this.chkUsarOperacion.Name = "chkUsarOperacion";
            this.chkUsarOperacion.Size = new System.Drawing.Size(111, 17);
            this.chkUsarOperacion.TabIndex = 319;
            this.chkUsarOperacion.Text = "Usar Operaciones";
            this.chkUsarOperacion.UseVisualStyleBackColor = true;
            this.chkUsarOperacion.CheckedChanged += new System.EventHandler(this.chkUsarOperacion_CheckedChanged);
            // 
            // cboOperaciones
            // 
            this.cboOperaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperaciones.Enabled = false;
            this.cboOperaciones.FormattingEnabled = true;
            this.cboOperaciones.Location = new System.Drawing.Point(293, 94);
            this.cboOperaciones.Name = "cboOperaciones";
            this.cboOperaciones.Size = new System.Drawing.Size(553, 21);
            this.cboOperaciones.TabIndex = 322;
            // 
            // rbOperaciones
            // 
            this.rbOperaciones.AutoSize = true;
            this.rbOperaciones.Checked = true;
            this.rbOperaciones.Location = new System.Drawing.Point(178, 6);
            this.rbOperaciones.Name = "rbOperaciones";
            this.rbOperaciones.Size = new System.Drawing.Size(119, 17);
            this.rbOperaciones.TabIndex = 323;
            this.rbOperaciones.TabStop = true;
            this.rbOperaciones.Text = "Cargar Operaciones";
            this.rbOperaciones.UseVisualStyleBackColor = true;
            this.rbOperaciones.CheckedChanged += new System.EventHandler(this.rbOperaciones_CheckedChanged);
            // 
            // rbAlmacenes
            // 
            this.rbAlmacenes.AutoSize = true;
            this.rbAlmacenes.Location = new System.Drawing.Point(344, 6);
            this.rbAlmacenes.Name = "rbAlmacenes";
            this.rbAlmacenes.Size = new System.Drawing.Size(111, 17);
            this.rbAlmacenes.TabIndex = 324;
            this.rbAlmacenes.Text = "Cargar Almacenes";
            this.rbAlmacenes.UseVisualStyleBackColor = true;
            this.rbAlmacenes.CheckedChanged += new System.EventHandler(this.rbAlmacenes_CheckedChanged);
            // 
            // rbKardex
            // 
            this.rbKardex.AutoSize = true;
            this.rbKardex.Location = new System.Drawing.Point(498, 6);
            this.rbKardex.Name = "rbKardex";
            this.rbKardex.Size = new System.Drawing.Size(92, 17);
            this.rbKardex.TabIndex = 325;
            this.rbKardex.Text = "Cargar Kárdex";
            this.rbKardex.UseVisualStyleBackColor = true;
            this.rbKardex.CheckedChanged += new System.EventHandler(this.rbKardex_CheckedChanged);
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacenes.Enabled = false;
            this.cboAlmacenes.FormattingEnabled = true;
            this.cboAlmacenes.Location = new System.Drawing.Point(293, 117);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(553, 21);
            this.cboAlmacenes.TabIndex = 322;
            // 
            // btRevisarLotes
            // 
            this.btRevisarLotes.BackColor = System.Drawing.Color.Azure;
            this.btRevisarLotes.Enabled = false;
            this.btRevisarLotes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btRevisarLotes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btRevisarLotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btRevisarLotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRevisarLotes.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRevisarLotes.Image = global::ClienteWinForm.Properties.Resources.DBFind;
            this.btRevisarLotes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRevisarLotes.Location = new System.Drawing.Point(787, 29);
            this.btRevisarLotes.Margin = new System.Windows.Forms.Padding(2);
            this.btRevisarLotes.Name = "btRevisarLotes";
            this.btRevisarLotes.Size = new System.Drawing.Size(59, 62);
            this.btRevisarLotes.TabIndex = 326;
            this.btRevisarLotes.Text = "Rev. Lote";
            this.btRevisarLotes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRevisarLotes.UseVisualStyleBackColor = false;
            this.btRevisarLotes.Click += new System.EventHandler(this.btRevisarLotes_Click);
            // 
            // lblregistros
            // 
            this.lblregistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.Size = new System.Drawing.Size(608, 18);
            this.lblregistros.TabIndex = 1575;
            this.lblregistros.Text = "Ruta del Archivo";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmImportarRegistroKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 196);
            this.Controls.Add(this.btRevisarLotes);
            this.Controls.Add(this.rbKardex);
            this.Controls.Add(this.rbAlmacenes);
            this.Controls.Add(this.rbOperaciones);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.cboOperaciones);
            this.Controls.Add(this.chkUsarAlmacen);
            this.Controls.Add(this.chkUsarOperacion);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btIntegrar);
            this.Controls.Add(this.bterrores);
            this.Controls.Add(this.btProcesar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.btCancelar);
            this.Name = "frmImportarRegistroKardex";
            this.Text = "Importar Registro de Kardex (*.xlsx)";
            this.Load += new System.EventHandler(this.frmImportarRegistroKardex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btIntegrar;
        private System.Windows.Forms.Button bterrores;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.CheckBox chkUsarAlmacen;
        private System.Windows.Forms.CheckBox chkUsarOperacion;
        private System.Windows.Forms.ComboBox cboOperaciones;
        private System.Windows.Forms.RadioButton rbOperaciones;
        private System.Windows.Forms.RadioButton rbAlmacenes;
        private System.Windows.Forms.RadioButton rbKardex;
        private System.Windows.Forms.ComboBox cboAlmacenes;
        private System.Windows.Forms.Button btRevisarLotes;
        private System.Windows.Forms.Label lblregistros;
    }
}