﻿namespace ClienteWinForm.Ventas.Reportes
{
    partial class frmReporteRegistroVentasDetalladaOT
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRazonCliente = new ControlesWinForm.SuperTextBox();
            this.txtRucCLiente = new ControlesWinForm.SuperTextBox();
            this.txtNombresVendedor = new ControlesWinForm.SuperTextBox();
            this.txtNroDocumentoVen = new ControlesWinForm.SuperTextBox();
            this.txtIdCliente = new ControlesWinForm.SuperTextBox();
            this.txtIdVendedor = new ControlesWinForm.SuperTextBox();
            this.chkVendedores = new System.Windows.Forms.CheckBox();
            this.chbClientes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.lblLetras = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(this.txtRazonCliente);
            this.panel1.Controls.Add(this.txtRucCLiente);
            this.panel1.Controls.Add(this.txtNombresVendedor);
            this.panel1.Controls.Add(this.txtNroDocumentoVen);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.txtIdVendedor);
            this.panel1.Controls.Add(this.chkVendedores);
            this.panel1.Controls.Add(this.chbClientes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFin);
            this.panel1.Controls.Add(this.dtpInicio);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 82);
            this.panel1.TabIndex = 291;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtRazonCliente
            // 
            this.txtRazonCliente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonCliente.BackColor = System.Drawing.Color.White;
            this.txtRazonCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonCliente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonCliente.Location = new System.Drawing.Point(525, 27);
            this.txtRazonCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonCliente.Name = "txtRazonCliente";
            this.txtRazonCliente.Size = new System.Drawing.Size(271, 20);
            this.txtRazonCliente.TabIndex = 370;
            this.txtRazonCliente.TabStop = false;
            this.txtRazonCliente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonCliente.TextoVacio = "<Descripcion>";
            this.txtRazonCliente.TextChanged += new System.EventHandler(this.txtRazonCliente_TextChanged);
            this.txtRazonCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonCliente_Validating);
            // 
            // txtRucCLiente
            // 
            this.txtRucCLiente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucCLiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRucCLiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRucCLiente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucCLiente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucCLiente.Location = new System.Drawing.Point(454, 27);
            this.txtRucCLiente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRucCLiente.Name = "txtRucCLiente";
            this.txtRucCLiente.Size = new System.Drawing.Size(69, 20);
            this.txtRucCLiente.TabIndex = 369;
            this.txtRucCLiente.TabStop = false;
            this.txtRucCLiente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucCLiente.TextoVacio = "<Descripcion>";
            this.txtRucCLiente.TextChanged += new System.EventHandler(this.txtRucCLiente_TextChanged);
            this.txtRucCLiente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRucCLiente_Validating);
            // 
            // txtNombresVendedor
            // 
            this.txtNombresVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombresVendedor.BackColor = System.Drawing.Color.White;
            this.txtNombresVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombresVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombresVendedor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombresVendedor.Location = new System.Drawing.Point(525, 50);
            this.txtNombresVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombresVendedor.Name = "txtNombresVendedor";
            this.txtNombresVendedor.Size = new System.Drawing.Size(271, 20);
            this.txtNombresVendedor.TabIndex = 368;
            this.txtNombresVendedor.TabStop = false;
            this.txtNombresVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombresVendedor.TextoVacio = "<Descripcion>";
            this.txtNombresVendedor.TextChanged += new System.EventHandler(this.txtNombresVendedor_TextChanged);
            this.txtNombresVendedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombresVendedor_Validating);
            // 
            // txtNroDocumentoVen
            // 
            this.txtNroDocumentoVen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNroDocumentoVen.BackColor = System.Drawing.Color.White;
            this.txtNroDocumentoVen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroDocumentoVen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNroDocumentoVen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDocumentoVen.Location = new System.Drawing.Point(454, 50);
            this.txtNroDocumentoVen.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroDocumentoVen.Name = "txtNroDocumentoVen";
            this.txtNroDocumentoVen.Size = new System.Drawing.Size(69, 20);
            this.txtNroDocumentoVen.TabIndex = 367;
            this.txtNroDocumentoVen.TabStop = false;
            this.txtNroDocumentoVen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNroDocumentoVen.TextoVacio = "<Descripcion>";
            this.txtNroDocumentoVen.TextChanged += new System.EventHandler(this.txtNroDocumentoVen_TextChanged);
            this.txtNroDocumentoVen.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroDocumentoVen_Validating);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCliente.BackColor = System.Drawing.Color.White;
            this.txtIdCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCliente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(442, 27);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(10, 20);
            this.txtIdCliente.TabIndex = 366;
            this.txtIdCliente.TabStop = false;
            this.txtIdCliente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdCliente.TextoVacio = "<Descripcion>";
            this.txtIdCliente.Visible = false;
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdVendedor.BackColor = System.Drawing.Color.White;
            this.txtIdVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdVendedor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdVendedor.Location = new System.Drawing.Point(441, 50);
            this.txtIdVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(10, 20);
            this.txtIdVendedor.TabIndex = 363;
            this.txtIdVendedor.TabStop = false;
            this.txtIdVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdVendedor.TextoVacio = "<Descripcion>";
            this.txtIdVendedor.Visible = false;
            // 
            // chkVendedores
            // 
            this.chkVendedores.AutoSize = true;
            this.chkVendedores.Checked = true;
            this.chkVendedores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendedores.Location = new System.Drawing.Point(329, 51);
            this.chkVendedores.Name = "chkVendedores";
            this.chkVendedores.Size = new System.Drawing.Size(116, 17);
            this.chkVendedores.TabIndex = 360;
            this.chkVendedores.Text = "Todos Vendedores";
            this.chkVendedores.UseVisualStyleBackColor = true;
            this.chkVendedores.CheckedChanged += new System.EventHandler(this.chkVendedores_CheckedChanged);
            // 
            // chbClientes
            // 
            this.chbClientes.AutoSize = true;
            this.chbClientes.Checked = true;
            this.chbClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbClientes.Location = new System.Drawing.Point(329, 30);
            this.chbClientes.Name = "chbClientes";
            this.chbClientes.Size = new System.Drawing.Size(96, 17);
            this.chbClientes.TabIndex = 356;
            this.chbClientes.Text = "Todos Clientes";
            this.chbClientes.UseVisualStyleBackColor = true;
            this.chbClientes.CheckedChanged += new System.EventHandler(this.chbClientes_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 262;
            this.label2.Text = "Fecha Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 261;
            this.label1.Text = "Fecha Inicio";
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(228, 27);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFin.TabIndex = 260;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(73, 27);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(96, 20);
            this.dtpInicio.TabIndex = 259;
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
            this.btBuscar.Location = new System.Drawing.Point(814, 26);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 47);
            this.btBuscar.TabIndex = 290;
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
            this.panel3.Location = new System.Drawing.Point(4, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 405);
            this.panel3.TabIndex = 289;
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
            this.lblProcesando.SizeChanged += new System.EventHandler(this.lblProcesando_SizeChanged);
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
            this.wbNavegador.Size = new System.Drawing.Size(1051, 403);
            this.wbNavegador.TabIndex = 268;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(801, 18);
            this.lblLetras.TabIndex = 1574;
            this.lblLetras.Text = "Parámetros de Búsqueda";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReporteRegistroVentasDetalladaOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel3);
            this.Name = "frmReporteRegistroVentasDetalladaOT";
            this.Text = "Reporte Registro Ventas Detallada OT";
            this.Load += new System.EventHandler(this.frmReporteRegistroVentasDetalladaOT_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.CheckBox chkVendedores;
        private System.Windows.Forms.CheckBox chbClientes;
        public ControlesWinForm.SuperTextBox txtIdVendedor;
        public ControlesWinForm.SuperTextBox txtIdCliente;
        public ControlesWinForm.SuperTextBox txtNombresVendedor;
        public ControlesWinForm.SuperTextBox txtNroDocumentoVen;
        public ControlesWinForm.SuperTextBox txtRazonCliente;
        public ControlesWinForm.SuperTextBox txtRucCLiente;
        private System.Windows.Forms.Label lblLetras;
    }
}