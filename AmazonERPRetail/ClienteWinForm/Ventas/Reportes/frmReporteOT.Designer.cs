namespace ClienteWinForm.Ventas.Reportes
{
    partial class frmReporteOT
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
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtIdAuxiliar = new ControlesWinForm.SuperTextBox();
            this.rbTodosCLientes = new System.Windows.Forms.RadioButton();
            this.rbUnCliente = new System.Windows.Forms.RadioButton();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.rbTodas = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAreas = new System.Windows.Forms.CheckBox();
            this.cboAreas = new System.Windows.Forms.ComboBox();
            this.rbDesde = new System.Windows.Forms.RadioButton();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.lblLetras = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(109, 58);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(156, 21);
            this.cboEstado.TabIndex = 286;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 320;
            this.label5.Text = "Estado";
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.Azure;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btBuscar.Location = new System.Drawing.Point(848, 28);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 47);
            this.btBuscar.TabIndex = 287;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
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
            this.panel3.Location = new System.Drawing.Point(4, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1055, 394);
            this.panel3.TabIndex = 286;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.White;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.Location = new System.Drawing.Point(733, 375);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 19);
            this.lblProcesando.TabIndex = 325;
            this.lblProcesando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProcesando.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.White;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(757, 256);
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
            this.wbNavegador.Size = new System.Drawing.Size(1053, 392);
            this.wbNavegador.TabIndex = 268;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonSocial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(130, 63);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(231, 20);
            this.txtRazonSocial.TabIndex = 551;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Razón Social";
            this.txtRazonSocial.Leave += new System.EventHandler(this.txtRazonSocial_Leave);
            // 
            // txtIdAuxiliar
            // 
            this.txtIdAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtIdAuxiliar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdAuxiliar.Enabled = false;
            this.txtIdAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAuxiliar.Location = new System.Drawing.Point(13, 63);
            this.txtIdAuxiliar.Name = "txtIdAuxiliar";
            this.txtIdAuxiliar.Size = new System.Drawing.Size(41, 20);
            this.txtIdAuxiliar.TabIndex = 549;
            this.txtIdAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdAuxiliar.TextoVacio = "Id";
            this.txtIdAuxiliar.Leave += new System.EventHandler(this.txtIdAuxiliar_Leave);
            // 
            // rbTodosCLientes
            // 
            this.rbTodosCLientes.AutoSize = true;
            this.rbTodosCLientes.Checked = true;
            this.rbTodosCLientes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodosCLientes.Location = new System.Drawing.Point(11, 24);
            this.rbTodosCLientes.Name = "rbTodosCLientes";
            this.rbTodosCLientes.Size = new System.Drawing.Size(54, 17);
            this.rbTodosCLientes.TabIndex = 548;
            this.rbTodosCLientes.TabStop = true;
            this.rbTodosCLientes.Text = "Todos";
            this.rbTodosCLientes.UseVisualStyleBackColor = true;
            this.rbTodosCLientes.CheckedChanged += new System.EventHandler(this.rbTodosCLientes_CheckedChanged);
            // 
            // rbUnCliente
            // 
            this.rbUnCliente.AutoSize = true;
            this.rbUnCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnCliente.Location = new System.Drawing.Point(11, 43);
            this.rbUnCliente.Name = "rbUnCliente";
            this.rbUnCliente.Size = new System.Drawing.Size(66, 17);
            this.rbUnCliente.TabIndex = 547;
            this.rbUnCliente.Text = "Solo uno";
            this.rbUnCliente.UseVisualStyleBackColor = true;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(55, 63);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(74, 20);
            this.txtRuc.TabIndex = 550;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "RUC";
            this.txtRuc.Leave += new System.EventHandler(this.txtRuc_Leave);
            // 
            // rbTodas
            // 
            this.rbTodas.AutoSize = true;
            this.rbTodas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodas.Location = new System.Drawing.Point(3, 24);
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.Size = new System.Drawing.Size(54, 17);
            this.rbTodas.TabIndex = 545;
            this.rbTodas.Text = "Todas";
            this.rbTodas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 544;
            this.label2.Text = "hasta";
            // 
            // chkAreas
            // 
            this.chkAreas.AutoSize = true;
            this.chkAreas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAreas.Location = new System.Drawing.Point(3, 33);
            this.chkAreas.Name = "chkAreas";
            this.chkAreas.Size = new System.Drawing.Size(102, 17);
            this.chkAreas.TabIndex = 540;
            this.chkAreas.Text = "Todos las Areas";
            this.chkAreas.UseVisualStyleBackColor = true;
            this.chkAreas.CheckedChanged += new System.EventHandler(this.chkAreas_CheckedChanged);
            // 
            // cboAreas
            // 
            this.cboAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAreas.FormattingEnabled = true;
            this.cboAreas.Location = new System.Drawing.Point(109, 31);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Size = new System.Drawing.Size(157, 21);
            this.cboAreas.TabIndex = 539;
            // 
            // rbDesde
            // 
            this.rbDesde.AutoSize = true;
            this.rbDesde.Checked = true;
            this.rbDesde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesde.Location = new System.Drawing.Point(3, 43);
            this.rbDesde.Name = "rbDesde";
            this.rbDesde.Size = new System.Drawing.Size(55, 17);
            this.rbDesde.TabIndex = 543;
            this.rbDesde.TabStop = true;
            this.rbDesde.Text = "Desde";
            this.rbDesde.UseVisualStyleBackColor = true;
            this.rbDesde.CheckedChanged += new System.EventHandler(this.rbDesde_CheckedChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(59, 40);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 541;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(59, 63);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 542;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboEstado);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.chkAreas);
            this.panel2.Controls.Add(this.cboAreas);
            this.panel2.Location = new System.Drawing.Point(175, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 93);
            this.panel2.TabIndex = 552;
            // 
            // button2
            // 
            this.button2.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button2.Location = new System.Drawing.Point(1217, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 59);
            this.button2.TabIndex = 154;
            this.button2.Text = "BUSCAR";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblLetras);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.rbTodas);
            this.panel4.Controls.Add(this.dtpFinal);
            this.panel4.Controls.Add(this.dtpInicio);
            this.panel4.Controls.Add(this.rbDesde);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(168, 93);
            this.panel4.TabIndex = 553;
            // 
            // button3
            // 
            this.button3.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button3.Location = new System.Drawing.Point(1217, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 59);
            this.button3.TabIndex = 154;
            this.button3.Text = "BUSCAR";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Controls.Add(this.txtRazonSocial);
            this.panel5.Controls.Add(this.rbTodosCLientes);
            this.panel5.Controls.Add(this.txtIdAuxiliar);
            this.panel5.Controls.Add(this.txtRuc);
            this.panel5.Controls.Add(this.rbUnCliente);
            this.panel5.Location = new System.Drawing.Point(458, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(380, 93);
            this.panel5.TabIndex = 553;
            // 
            // button4
            // 
            this.button4.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button4.Location = new System.Drawing.Point(1217, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 59);
            this.button4.TabIndex = 154;
            this.button4.Text = "BUSCAR";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(166, 18);
            this.lblLetras.TabIndex = 1609;
            this.lblLetras.Text = "Fechas";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 18);
            this.label1.TabIndex = 1609;
            this.label1.Text = "Areas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 18);
            this.label3.TabIndex = 1609;
            this.label3.Text = "Cliente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReporteOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 500);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel3);
            this.Name = "frmReporteOT";
            this.Text = "Reporte Orden De Trabajo";
            this.Load += new System.EventHandler(this.frmReporteOT_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtIdAuxiliar;
        private System.Windows.Forms.RadioButton rbTodosCLientes;
        private System.Windows.Forms.RadioButton rbUnCliente;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.RadioButton rbTodas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAreas;
        private System.Windows.Forms.ComboBox cboAreas;
        private System.Windows.Forms.RadioButton rbDesde;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Panel panel2;
        protected internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        protected internal System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel5;
        protected internal System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLetras;
        private System.Windows.Forms.Label label3;
    }
}