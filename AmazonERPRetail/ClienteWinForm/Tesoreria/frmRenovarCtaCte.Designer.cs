namespace ClienteWinForm.Tesoreria
{
    partial class frmRenovarCtaCte
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
            System.Windows.Forms.Label idEmpresaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvCtaCte = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.cboSistema = new System.Windows.Forms.ComboBox();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.btEjecutar = new System.Windows.Forms.Button();
            this.btObtener = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            idEmpresaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtaCte)).BeginInit();
            this.pnlOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.BackColor = System.Drawing.Color.Transparent;
            idEmpresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idEmpresaLabel.Location = new System.Drawing.Point(144, 31);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new System.Drawing.Size(48, 13);
            idEmpresaLabel.TabIndex = 6;
            idEmpresaLabel.Text = "Empresa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(144, 54);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 13);
            label1.TabIndex = 365;
            label1.Text = "Sistema";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cbEmpresa.DisplayMember = "IdEmpresa";
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(198, 27);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(215, 21);
            this.cbEmpresa.TabIndex = 7;
            this.cbEmpresa.ValueMember = "IdEmpresa";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvCtaCte);
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 89);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(923, 349);
            this.pnlDetalle.TabIndex = 364;
            // 
            // dgvCtaCte
            // 
            this.dgvCtaCte.AllowUserToAddRows = false;
            this.dgvCtaCte.AllowUserToDeleteRows = false;
            this.dgvCtaCte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvCtaCte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCtaCte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtaCte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtaCte.EnableHeadersVisualStyles = false;
            this.dgvCtaCte.Location = new System.Drawing.Point(0, 18);
            this.dgvCtaCte.Name = "dgvCtaCte";
            this.dgvCtaCte.ReadOnly = true;
            this.dgvCtaCte.Size = new System.Drawing.Size(921, 329);
            this.dgvCtaCte.TabIndex = 248;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(921, 18);
            this.lblRegistros.TabIndex = 258;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSistema
            // 
            this.cboSistema.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cboSistema.DisplayMember = "NombreComercial";
            this.cboSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSistema.FormattingEnabled = true;
            this.cboSistema.Location = new System.Drawing.Point(198, 50);
            this.cboSistema.Name = "cboSistema";
            this.cboSistema.Size = new System.Drawing.Size(215, 21);
            this.cboSistema.TabIndex = 366;
            this.cboSistema.ValueMember = "IdEmpresa";
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpciones.Controls.Add(this.btEjecutar);
            this.pnlOpciones.Controls.Add(this.btObtener);
            this.pnlOpciones.Controls.Add(this.btLimpiar);
            this.pnlOpciones.Controls.Add(this.label2);
            this.pnlOpciones.Controls.Add(label1);
            this.pnlOpciones.Controls.Add(this.label25);
            this.pnlOpciones.Controls.Add(this.cboSistema);
            this.pnlOpciones.Controls.Add(this.dtpFecFin);
            this.pnlOpciones.Controls.Add(this.dtpFecIni);
            this.pnlOpciones.Controls.Add(idEmpresaLabel);
            this.pnlOpciones.Controls.Add(this.labelDegradado1);
            this.pnlOpciones.Controls.Add(this.cbEmpresa);
            this.pnlOpciones.Location = new System.Drawing.Point(4, 4);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(824, 82);
            this.pnlOpciones.TabIndex = 371;
            // 
            // btEjecutar
            // 
            this.btEjecutar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btEjecutar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btEjecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEjecutar.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.btEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEjecutar.Location = new System.Drawing.Point(715, 23);
            this.btEjecutar.Name = "btEjecutar";
            this.btEjecutar.Size = new System.Drawing.Size(94, 52);
            this.btEjecutar.TabIndex = 1589;
            this.btEjecutar.TabStop = false;
            this.btEjecutar.Text = "Ejecutar";
            this.btEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEjecutar.UseVisualStyleBackColor = true;
            this.btEjecutar.Click += new System.EventHandler(this.btEjecutar_Click);
            // 
            // btObtener
            // 
            this.btObtener.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btObtener.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btObtener.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btObtener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btObtener.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btObtener.Image = global::ClienteWinForm.Properties.Resources.BuscarDoc_48x48;
            this.btObtener.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btObtener.Location = new System.Drawing.Point(571, 23);
            this.btObtener.Name = "btObtener";
            this.btObtener.Size = new System.Drawing.Size(139, 52);
            this.btObtener.TabIndex = 1588;
            this.btObtener.TabStop = false;
            this.btObtener.Text = "Obtener Docum.";
            this.btObtener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btObtener.UseVisualStyleBackColor = true;
            this.btObtener.Click += new System.EventHandler(this.btObtener_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Image = global::ClienteWinForm.Properties.Resources.Borrar_48x48;
            this.btLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLimpiar.Location = new System.Drawing.Point(427, 23);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(139, 52);
            this.btLimpiar.TabIndex = 1587;
            this.btLimpiar.TabStop = false;
            this.btLimpiar.Text = "Limpiar Cta.Cte.";
            this.btLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 371;
            this.label2.Text = "Del";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(17, 54);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 370;
            this.label25.Text = "Al";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(45, 50);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(87, 20);
            this.dtpFecFin.TabIndex = 369;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(45, 27);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(87, 20);
            this.dtpFecIni.TabIndex = 368;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(822, 18);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Opciones de Busqueda";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbProgress.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(852, 22);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(53, 50);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 1590;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // frmRenovarCtaCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 442);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmRenovarCtaCte";
            this.Text = "Transferencia de Cta. Cte.";
            this.Load += new System.EventHandler(this.frmRenovarCtaCte_Load);
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtaCte)).EndInit();
            this.pnlOpciones.ResumeLayout(false);
            this.pnlOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvCtaCte;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.ComboBox cboSistema;
        private System.Windows.Forms.Panel pnlOpciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btObtener;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btEjecutar;
        private System.Windows.Forms.PictureBox pbProgress;
    }
}