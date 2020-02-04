namespace ClienteWinForm.Contabilidad
{
    partial class frmImportarVentasDet
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
            this.txtCCostos = new ControlesWinForm.SuperTextBox();
            this.txtDesCCostos = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btAuxiliares = new System.Windows.Forms.Button();
            this.btGenerarVoucher = new System.Windows.Forms.Button();
            this.cboSistema = new System.Windows.Forms.ComboBox();
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
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblRegistros.Location = new System.Drawing.Point(179, 135);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(0, 13);
            this.lblRegistros.TabIndex = 320;
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
            this.btCancelar.Location = new System.Drawing.Point(401, 108);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(60, 49);
            this.btCancelar.TabIndex = 319;
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
            this.btIntegrar.Location = new System.Drawing.Point(653, 108);
            this.btIntegrar.Margin = new System.Windows.Forms.Padding(2);
            this.btIntegrar.Name = "btIntegrar";
            this.btIntegrar.Size = new System.Drawing.Size(60, 49);
            this.btIntegrar.TabIndex = 318;
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
            this.btErrores.Location = new System.Drawing.Point(590, 108);
            this.btErrores.Margin = new System.Windows.Forms.Padding(2);
            this.btErrores.Name = "btErrores";
            this.btErrores.Size = new System.Drawing.Size(60, 49);
            this.btErrores.TabIndex = 317;
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
            this.lblProcesando.Location = new System.Drawing.Point(179, 115);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 13);
            this.lblProcesando.TabIndex = 316;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(134, 112);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(40, 38);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 315;
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
            this.btProcesar.Location = new System.Drawing.Point(527, 108);
            this.btProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(60, 49);
            this.btProcesar.TabIndex = 314;
            this.btProcesar.Text = "Procesar";
            this.btProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btProcesar.UseVisualStyleBackColor = false;
            this.btProcesar.Click += new System.EventHandler(this.btProcesar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btActualizar.Enabled = false;
            this.btActualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizar.Image = global::ClienteWinForm.Properties.Resources.ActualizarExcel;
            this.btActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btActualizar.Location = new System.Drawing.Point(464, 108);
            this.btActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(60, 49);
            this.btActualizar.TabIndex = 313;
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
            this.panel1.Location = new System.Drawing.Point(132, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 62);
            this.panel1.TabIndex = 312;
            // 
            // btExaminar
            // 
            this.btExaminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExaminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExaminar.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExaminar.Location = new System.Drawing.Point(552, 27);
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
            this.txtRuta.Location = new System.Drawing.Point(13, 27);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(536, 21);
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
            this.labelDegradado1.Size = new System.Drawing.Size(643, 17);
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
            this.pbImagen.Size = new System.Drawing.Size(124, 151);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 311;
            this.pbImagen.TabStop = false;
            // 
            // txtCCostos
            // 
            this.txtCCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCCostos.Enabled = false;
            this.txtCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCostos.Location = new System.Drawing.Point(188, 69);
            this.txtCCostos.Name = "txtCCostos";
            this.txtCCostos.Size = new System.Drawing.Size(83, 20);
            this.txtCCostos.TabIndex = 1502;
            this.txtCCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCCostos.TextoVacio = "<Descripcion>";
            // 
            // txtDesCCostos
            // 
            this.txtDesCCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCCostos.Enabled = false;
            this.txtDesCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCCostos.Location = new System.Drawing.Point(274, 69);
            this.txtDesCCostos.Name = "txtDesCCostos";
            this.txtDesCCostos.ReadOnly = true;
            this.txtDesCCostos.Size = new System.Drawing.Size(313, 20);
            this.txtDesCCostos.TabIndex = 1501;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(134, 73);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 13);
            this.label27.TabIndex = 1503;
            this.label27.Text = "C. Costos";
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
            this.btAuxiliares.Location = new System.Drawing.Point(653, 108);
            this.btAuxiliares.Margin = new System.Windows.Forms.Padding(2);
            this.btAuxiliares.Name = "btAuxiliares";
            this.btAuxiliares.Size = new System.Drawing.Size(60, 49);
            this.btAuxiliares.TabIndex = 1505;
            this.btAuxiliares.Text = "Crear Auxiliar";
            this.btAuxiliares.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAuxiliares.UseVisualStyleBackColor = false;
            this.btAuxiliares.Visible = false;
            this.btAuxiliares.Click += new System.EventHandler(this.btAuxiliares_Click);
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
            this.btGenerarVoucher.Location = new System.Drawing.Point(717, 108);
            this.btGenerarVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.btGenerarVoucher.Name = "btGenerarVoucher";
            this.btGenerarVoucher.Size = new System.Drawing.Size(60, 49);
            this.btGenerarVoucher.TabIndex = 1506;
            this.btGenerarVoucher.Text = "Vouchers";
            this.btGenerarVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGenerarVoucher.UseVisualStyleBackColor = false;
            this.btGenerarVoucher.Click += new System.EventHandler(this.btGenerarVoucher_Click);
            // 
            // cboSistema
            // 
            this.cboSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistema.DropDownWidth = 188;
            this.cboSistema.Enabled = false;
            this.cboSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSistema.FormattingEnabled = true;
            this.cboSistema.Items.AddRange(new object[] {
            "FULL STATION",
            "GASOLUTION"});
            this.cboSistema.Location = new System.Drawing.Point(590, 69);
            this.cboSistema.Name = "cboSistema";
            this.cboSistema.Size = new System.Drawing.Size(188, 21);
            this.cboSistema.TabIndex = 1507;
            // 
            // frmImportarVentasDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 161);
            this.Controls.Add(this.cboSistema);
            this.Controls.Add(this.btGenerarVoucher);
            this.Controls.Add(this.txtCCostos);
            this.Controls.Add(this.txtDesCCostos);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btErrores);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btProcesar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btIntegrar);
            this.Controls.Add(this.btAuxiliares);
            this.MaximizeBox = false;
            this.Name = "frmImportarVentasDet";
            this.Text = "Importar Ventas Detallada";
            this.Load += new System.EventHandler(this.frmImportarVentasDet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btIntegrar;
        private System.Windows.Forms.Button btErrores;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.TextBox txtRuta;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.PictureBox pbImagen;
        private ControlesWinForm.SuperTextBox txtCCostos;
        private System.Windows.Forms.TextBox txtDesCCostos;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btAuxiliares;
        private System.Windows.Forms.Button btGenerarVoucher;
        private System.Windows.Forms.ComboBox cboSistema;
    }
}