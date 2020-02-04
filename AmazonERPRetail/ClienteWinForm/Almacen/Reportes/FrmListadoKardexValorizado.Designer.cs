﻿namespace ClienteWinForm.Almacen.Reportes
{
    partial class FrmListadoKardexValorizado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListadoKardexValorizado));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblregistros = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoAlmacen = new System.Windows.Forms.ComboBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.btObtener = new System.Windows.Forms.Button();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomArt = new ControlesWinForm.SuperTextBox();
            this.txtArt = new ControlesWinForm.SuperTextBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbUno = new System.Windows.Forms.RadioButton();
            this.btPle = new System.Windows.Forms.Button();
            this.btExportar = new System.Windows.Forms.Button();
            this.cmsFormatos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmFormato1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFormato2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bskardexValorizado = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cmsFormatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bskardexValorizado)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblregistros);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFinal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpInicio);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 63);
            this.panel1.TabIndex = 273;
            // 
            // lblregistros
            // 
            this.lblregistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.Size = new System.Drawing.Size(243, 18);
            this.lblregistros.TabIndex = 1575;
            this.lblregistros.Text = "Fechas";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "De";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(141, 28);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 260;
            this.dtpFinal.Value = new System.DateTime(2016, 12, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 261;
            this.label2.Text = "a";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(31, 28);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 259;
            this.dtpInicio.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cboTipoAlmacen);
            this.panel3.Controls.Add(this.cboAlmacen);
            this.panel3.Location = new System.Drawing.Point(250, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(403, 63);
            this.panel3.TabIndex = 275;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 18);
            this.label3.TabIndex = 1575;
            this.label3.Text = "Almacén";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTipoAlmacen
            // 
            this.cboTipoAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAlmacen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoAlmacen.FormattingEnabled = true;
            this.cboTipoAlmacen.Location = new System.Drawing.Point(7, 29);
            this.cboTipoAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoAlmacen.Name = "cboTipoAlmacen";
            this.cboTipoAlmacen.Size = new System.Drawing.Size(156, 21);
            this.cboTipoAlmacen.TabIndex = 350;
            this.cboTipoAlmacen.SelectionChangeCommitted += new System.EventHandler(this.cboTipoAlmacen_SelectionChangeCommitted);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(167, 29);
            this.cboAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(227, 21);
            this.cboAlmacen.TabIndex = 261;
            // 
            // btObtener
            // 
            this.btObtener.BackColor = System.Drawing.Color.Azure;
            this.btObtener.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btObtener.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btObtener.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btObtener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btObtener.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btObtener.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btObtener.Location = new System.Drawing.Point(1026, 10);
            this.btObtener.Margin = new System.Windows.Forms.Padding(2);
            this.btObtener.Name = "btObtener";
            this.btObtener.Size = new System.Drawing.Size(51, 48);
            this.btObtener.TabIndex = 288;
            this.btObtener.UseVisualStyleBackColor = false;
            this.btObtener.Click += new System.EventHandler(this.btObtener_Click);
            // 
            // wbNavegador
            // 
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(1187, 365);
            this.wbNavegador.TabIndex = 330;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNomArt);
            this.panel2.Controls.Add(this.txtArt);
            this.panel2.Controls.Add(this.rbTodos);
            this.panel2.Controls.Add(this.rbUno);
            this.panel2.Location = new System.Drawing.Point(656, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 63);
            this.panel2.TabIndex = 276;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(363, 18);
            this.label4.TabIndex = 1575;
            this.label4.Text = "Articulo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomArt
            // 
            this.txtNomArt.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtNomArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNomArt.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNomArt.Enabled = false;
            this.txtNomArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomArt.Location = new System.Drawing.Point(67, 38);
            this.txtNomArt.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomArt.Name = "txtNomArt";
            this.txtNomArt.Size = new System.Drawing.Size(289, 20);
            this.txtNomArt.TabIndex = 332;
            this.txtNomArt.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNomArt.TextoVacio = "Producto";
            this.txtNomArt.TextChanged += new System.EventHandler(this.txtNomArt_TextChanged);
            this.txtNomArt.Validating += new System.ComponentModel.CancelEventHandler(this.txtNomArt_Validating);
            // 
            // txtArt
            // 
            this.txtArt.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtArt.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtArt.Enabled = false;
            this.txtArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArt.Location = new System.Drawing.Point(4, 38);
            this.txtArt.Margin = new System.Windows.Forms.Padding(2);
            this.txtArt.Name = "txtArt";
            this.txtArt.Size = new System.Drawing.Size(61, 20);
            this.txtArt.TabIndex = 331;
            this.txtArt.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtArt.TextoVacio = "Código";
            this.txtArt.TextChanged += new System.EventHandler(this.txtArt_TextChanged);
            this.txtArt.Validating += new System.ComponentModel.CancelEventHandler(this.txtArt_Validating);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(11, 19);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(54, 17);
            this.rbTodos.TabIndex = 354;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // rbUno
            // 
            this.rbUno.AutoSize = true;
            this.rbUno.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUno.Location = new System.Drawing.Point(72, 19);
            this.rbUno.Name = "rbUno";
            this.rbUno.Size = new System.Drawing.Size(66, 17);
            this.rbUno.TabIndex = 353;
            this.rbUno.Text = "Solo uno";
            this.rbUno.UseVisualStyleBackColor = true;
            // 
            // btPle
            // 
            this.btPle.BackColor = System.Drawing.Color.Azure;
            this.btPle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btPle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btPle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btPle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPle.Image = ((System.Drawing.Image)(resources.GetObject("btPle.Image")));
            this.btPle.Location = new System.Drawing.Point(1080, 10);
            this.btPle.Margin = new System.Windows.Forms.Padding(2);
            this.btPle.Name = "btPle";
            this.btPle.Size = new System.Drawing.Size(51, 48);
            this.btPle.TabIndex = 331;
            this.btPle.TabStop = false;
            this.btPle.UseVisualStyleBackColor = false;
            this.btPle.Click += new System.EventHandler(this.btPle_Click);
            // 
            // btExportar
            // 
            this.btExportar.BackColor = System.Drawing.Color.Azure;
            this.btExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExportar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportar.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.btExportar.Location = new System.Drawing.Point(1134, 10);
            this.btExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(51, 48);
            this.btExportar.TabIndex = 335;
            this.btExportar.UseVisualStyleBackColor = false;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            this.btExportar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btExportar_MouseUp);
            // 
            // cmsFormatos
            // 
            this.cmsFormatos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsFormatos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFormato1,
            this.tsmFormato2});
            this.cmsFormatos.Name = "cmsFormatos";
            this.cmsFormatos.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsFormatos.Size = new System.Drawing.Size(161, 48);
            // 
            // tsmFormato1
            // 
            this.tsmFormato1.Name = "tsmFormato1";
            this.tsmFormato1.Size = new System.Drawing.Size(160, 22);
            this.tsmFormato1.Text = "Formato Listado";
            this.tsmFormato1.Click += new System.EventHandler(this.tsmFormato1_Click);
            // 
            // tsmFormato2
            // 
            this.tsmFormato2.Name = "tsmFormato2";
            this.tsmFormato2.Size = new System.Drawing.Size(160, 22);
            this.tsmFormato2.Text = "Formato Kardex";
            this.tsmFormato2.Click += new System.EventHandler(this.tsmFormato2_Click);
            // 
            // bskardexValorizado
            // 
            this.bskardexValorizado.DataSource = typeof(Entidades.Almacen.KardexValorizadoE);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.wbNavegador);
            this.panel4.Location = new System.Drawing.Point(3, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1189, 367);
            this.panel4.TabIndex = 336;
            // 
            // FrmListadoKardexValorizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 439);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btExportar);
            this.Controls.Add(this.btPle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btObtener);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmListadoKardexValorizado";
            this.Text = "Valorización del Kardex";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmListadoKardexValorizado_FormClosing);
            this.Load += new System.EventHandler(this.FrmListadoKardexValorizado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cmsFormatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bskardexValorizado)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.BindingSource bskardexValorizado;
        private System.Windows.Forms.Button btObtener;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbUno;
        private ControlesWinForm.SuperTextBox txtArt;
        private ControlesWinForm.SuperTextBox txtNomArt;
        private System.Windows.Forms.Button btPle;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.ContextMenuStrip cmsFormatos;
        private System.Windows.Forms.ToolStripMenuItem tsmFormato1;
        private System.Windows.Forms.ToolStripMenuItem tsmFormato2;
        private System.Windows.Forms.ComboBox cboTipoAlmacen;
        private System.Windows.Forms.Label lblregistros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
    }
}