namespace ClienteWinForm.Contabilidad
{
    partial class frmImportarRegistroBalanceComprobacion
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
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btIntegrar = new System.Windows.Forms.Button();
            this.btErrores = new System.Windows.Forms.Button();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.btProcesar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExaminar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkCuentaEquivalente = new System.Windows.Forms.CheckBox();
            this.btBuscarEquivalente = new System.Windows.Forms.Button();
            this.txtRutaCuentas = new System.Windows.Forms.TextBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblRegistros.Location = new System.Drawing.Point(100, 195);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(0, 13);
            this.lblRegistros.TabIndex = 310;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCancelar.Enabled = false;
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(383, 163);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(63, 47);
            this.btCancelar.TabIndex = 309;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btIntegrar
            // 
            this.btIntegrar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btIntegrar.Enabled = false;
            this.btIntegrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btIntegrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btIntegrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btIntegrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIntegrar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIntegrar.Image = global::ClienteWinForm.Properties.Resources.Generar;
            this.btIntegrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btIntegrar.Location = new System.Drawing.Point(647, 163);
            this.btIntegrar.Margin = new System.Windows.Forms.Padding(2);
            this.btIntegrar.Name = "btIntegrar";
            this.btIntegrar.Size = new System.Drawing.Size(63, 47);
            this.btIntegrar.TabIndex = 308;
            this.btIntegrar.Text = "Integrar";
            this.btIntegrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btIntegrar.UseVisualStyleBackColor = false;
            this.btIntegrar.Click += new System.EventHandler(this.btIntegrar_Click);
            // 
            // btErrores
            // 
            this.btErrores.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btErrores.Enabled = false;
            this.btErrores.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btErrores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btErrores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btErrores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btErrores.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btErrores.Image = global::ClienteWinForm.Properties.Resources.borrar_registro;
            this.btErrores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btErrores.Location = new System.Drawing.Point(581, 163);
            this.btErrores.Margin = new System.Windows.Forms.Padding(2);
            this.btErrores.Name = "btErrores";
            this.btErrores.Size = new System.Drawing.Size(63, 47);
            this.btErrores.TabIndex = 307;
            this.btErrores.Text = "Errores";
            this.btErrores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btErrores.UseVisualStyleBackColor = false;
            this.btErrores.Click += new System.EventHandler(this.btErrores_Click);
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.Transparent;
            this.lblProcesando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblProcesando.Location = new System.Drawing.Point(100, 175);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 13);
            this.lblProcesando.TabIndex = 306;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(53, 172);
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
            this.btProcesar.Location = new System.Drawing.Point(515, 163);
            this.btProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(63, 47);
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
            this.btActualizar.Location = new System.Drawing.Point(449, 163);
            this.btActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(63, 47);
            this.btActualizar.TabIndex = 301;
            this.btActualizar.Text = "Actualizar";
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
            this.panel1.Location = new System.Drawing.Point(116, 71);
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
            this.btExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExaminar.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExaminar.Location = new System.Drawing.Point(504, 28);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(71, 20);
            this.btExaminar.TabIndex = 295;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.pbImagen.Location = new System.Drawing.Point(3, 3);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(111, 130);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkCuentaEquivalente);
            this.panel2.Controls.Add(this.btBuscarEquivalente);
            this.panel2.Controls.Add(this.txtRutaCuentas);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Location = new System.Drawing.Point(115, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 62);
            this.panel2.TabIndex = 301;
            // 
            // chkCuentaEquivalente
            // 
            this.chkCuentaEquivalente.AutoSize = true;
            this.chkCuentaEquivalente.BackColor = System.Drawing.Color.SlateGray;
            this.chkCuentaEquivalente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCuentaEquivalente.Checked = true;
            this.chkCuentaEquivalente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCuentaEquivalente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCuentaEquivalente.ForeColor = System.Drawing.Color.White;
            this.chkCuentaEquivalente.Location = new System.Drawing.Point(2, 0);
            this.chkCuentaEquivalente.Name = "chkCuentaEquivalente";
            this.chkCuentaEquivalente.Size = new System.Drawing.Size(169, 17);
            this.chkCuentaEquivalente.TabIndex = 311;
            this.chkCuentaEquivalente.Text = "Con Cuenta Equivalentes";
            this.chkCuentaEquivalente.UseVisualStyleBackColor = false;
            this.chkCuentaEquivalente.CheckedChanged += new System.EventHandler(this.chkCuentaEquivalente_CheckedChanged);
            // 
            // btBuscarEquivalente
            // 
            this.btBuscarEquivalente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarEquivalente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscarEquivalente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarEquivalente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarEquivalente.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarEquivalente.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarEquivalente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscarEquivalente.Location = new System.Drawing.Point(504, 28);
            this.btBuscarEquivalente.Name = "btBuscarEquivalente";
            this.btBuscarEquivalente.Size = new System.Drawing.Size(71, 20);
            this.btBuscarEquivalente.TabIndex = 295;
            this.btBuscarEquivalente.Text = "Examinar";
            this.btBuscarEquivalente.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btBuscarEquivalente.UseVisualStyleBackColor = true;
            this.btBuscarEquivalente.Click += new System.EventHandler(this.btBuscarEquivalente_Click);
            // 
            // txtRutaCuentas
            // 
            this.txtRutaCuentas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRutaCuentas.Enabled = false;
            this.txtRutaCuentas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaCuentas.Location = new System.Drawing.Point(9, 27);
            this.txtRutaCuentas.Name = "txtRutaCuentas";
            this.txtRutaCuentas.ReadOnly = true;
            this.txtRutaCuentas.Size = new System.Drawing.Size(492, 21);
            this.txtRutaCuentas.TabIndex = 297;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(595, 17);
            this.labelDegradado2.TabIndex = 248;
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(615, 137);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 311;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 312;
            this.label1.Text = "Ingrese la fecha del asiento contable";
            // 
            // frmImportarRegistroBalanceComprobacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 213);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btErrores);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btIntegrar);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btProcesar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbImagen);
            this.MaximizeBox = false;
            this.Name = "frmImportarRegistroBalanceComprobacion";
            this.Text = "Importar Balance Comprobación  (*.xls, *.xlsx)";
            this.Load += new System.EventHandler(this.frmImportarRegistroVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button btErrores;
        private System.Windows.Forms.Button btIntegrar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkCuentaEquivalente;
        private System.Windows.Forms.Button btBuscarEquivalente;
        private System.Windows.Forms.TextBox txtRutaCuentas;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
    }
}