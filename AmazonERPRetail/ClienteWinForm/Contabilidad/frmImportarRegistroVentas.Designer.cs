namespace ClienteWinForm.Contabilidad
{
    partial class frmImportarRegistroVentas
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
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInicio = new ControlesWinForm.SuperTextBox();
            this.btGenerarVoucher = new System.Windows.Forms.Button();
            this.btAuxiliares = new System.Windows.Forms.Button();
            this.lblAvance = new System.Windows.Forms.Label();
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
            this.lblProcesando.Location = new System.Drawing.Point(167, 113);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 13);
            this.lblProcesando.TabIndex = 306;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(121, 91);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(40, 38);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 304;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // btProcesar
            // 
            this.btProcesar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btProcesar.Enabled = false;
            this.btProcesar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btProcesar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btProcesar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProcesar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProcesar.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.btProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btProcesar.Location = new System.Drawing.Point(529, 78);
            this.btProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(60, 49);
            this.btProcesar.TabIndex = 302;
            this.btProcesar.Text = "Procesar";
            this.btProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btProcesar.UseVisualStyleBackColor = false;
            this.btProcesar.Click += new System.EventHandler(this.btProcesar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btActualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizar.Image = global::ClienteWinForm.Properties.Resources.ActualizarExcel;
            this.btActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btActualizar.Location = new System.Drawing.Point(464, 78);
            this.btActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(60, 49);
            this.btActualizar.TabIndex = 301;
            this.btActualizar.Text = "Cargar";
            this.btActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btExaminar);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(121, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 62);
            this.panel1.TabIndex = 300;
            // 
            // btExaminar
            // 
            this.btExaminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExaminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExaminar.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExaminar.Location = new System.Drawing.Point(504, 27);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(81, 21);
            this.btExaminar.TabIndex = 295;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExaminar.UseVisualStyleBackColor = true;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuta.Enabled = false;
            this.txtRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(9, 27);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(492, 21);
            this.txtRuta.TabIndex = 297;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(595, 17);
            this.labelDegradado1.TabIndex = 248;
            this.labelDegradado1.Text = "Ruta del Archivo";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Image = global::ClienteWinForm.Properties.Resources.HojaExcel;
            this.pbImagen.Location = new System.Drawing.Point(4, 4);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(114, 132);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Fila de Inicio Lectura";
            // 
            // txtInicio
            // 
            this.txtInicio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtInicio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtInicio.Location = new System.Drawing.Point(232, 69);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(35, 20);
            this.txtInicio.TabIndex = 309;
            this.txtInicio.Text = "10";
            this.txtInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInicio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtInicio.TextoVacio = "<Descripcion>";
            // 
            // btGenerarVoucher
            // 
            this.btGenerarVoucher.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btGenerarVoucher.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btGenerarVoucher.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btGenerarVoucher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btGenerarVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGenerarVoucher.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerarVoucher.Image = global::ClienteWinForm.Properties.Resources.settings;
            this.btGenerarVoucher.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btGenerarVoucher.Location = new System.Drawing.Point(656, 78);
            this.btGenerarVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.btGenerarVoucher.Name = "btGenerarVoucher";
            this.btGenerarVoucher.Size = new System.Drawing.Size(60, 49);
            this.btGenerarVoucher.TabIndex = 1507;
            this.btGenerarVoucher.Text = "Vouchers";
            this.btGenerarVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGenerarVoucher.UseVisualStyleBackColor = false;
            this.btGenerarVoucher.Click += new System.EventHandler(this.btGenerarVoucher_Click);
            // 
            // btAuxiliares
            // 
            this.btAuxiliares.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btAuxiliares.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAuxiliares.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAuxiliares.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAuxiliares.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAuxiliares.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAuxiliares.Image = global::ClienteWinForm.Properties.Resources.ico_persona;
            this.btAuxiliares.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAuxiliares.Location = new System.Drawing.Point(592, 78);
            this.btAuxiliares.Margin = new System.Windows.Forms.Padding(2);
            this.btAuxiliares.Name = "btAuxiliares";
            this.btAuxiliares.Size = new System.Drawing.Size(60, 49);
            this.btAuxiliares.TabIndex = 1508;
            this.btAuxiliares.Text = "Crear Auxiliar";
            this.btAuxiliares.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAuxiliares.UseVisualStyleBackColor = false;
            this.btAuxiliares.Click += new System.EventHandler(this.btAuxiliares_Click);
            // 
            // lblAvance
            // 
            this.lblAvance.AutoSize = true;
            this.lblAvance.BackColor = System.Drawing.Color.Transparent;
            this.lblAvance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblAvance.Location = new System.Drawing.Point(312, 73);
            this.lblAvance.Name = "lblAvance";
            this.lblAvance.Size = new System.Drawing.Size(0, 13);
            this.lblAvance.TabIndex = 1509;
            // 
            // frmImportarRegistroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 140);
            this.Controls.Add(this.lblAvance);
            this.Controls.Add(this.btGenerarVoucher);
            this.Controls.Add(this.txtInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btProcesar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btAuxiliares);
            this.MaximizeBox = false;
            this.Name = "frmImportarRegistroVentas";
            this.Text = "Importar Registro de Ventas (*.xls, *.xlsx)";
            this.Load += new System.EventHandler(this.frmImportarVentasDiarias_Load);
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
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtInicio;
        private System.Windows.Forms.Button btGenerarVoucher;
        private System.Windows.Forms.Button btAuxiliares;
        private System.Windows.Forms.Label lblAvance;
    }
}