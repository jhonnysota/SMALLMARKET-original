﻿namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteComprasVarias
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
            this.label5 = new System.Windows.Forms.Label();
            this.cboFlag = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSucursales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btBuscar = new System.Windows.Forms.Button();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboFlag);
            this.panel1.Controls.Add(this.cboAño);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboSucursales);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboMes);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 61);
            this.panel1.TabIndex = 287;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 320;
            this.label5.Text = "Flag Grabado";
            // 
            // cboFlag
            // 
            this.cboFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFlag.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFlag.FormattingEnabled = true;
            this.cboFlag.Location = new System.Drawing.Point(587, 28);
            this.cboFlag.Name = "cboFlag";
            this.cboFlag.Size = new System.Drawing.Size(82, 21);
            this.cboFlag.TabIndex = 318;
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(255, 28);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(64, 21);
            this.cboAño.TabIndex = 311;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 312;
            this.label4.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "Sucursal";
            // 
            // cboSucursales
            // 
            this.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursales.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursales.FormattingEnabled = true;
            this.cboSucursales.Location = new System.Drawing.Point(64, 28);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Size = new System.Drawing.Size(154, 21);
            this.cboSucursales.TabIndex = 309;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Mes";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(353, 28);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(154, 21);
            this.cboMes.TabIndex = 271;
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(685, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parámetros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btBuscar.Location = new System.Drawing.Point(707, 20);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 47);
            this.btBuscar.TabIndex = 286;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // wbNavegador
            // 
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(1205, 455);
            this.wbNavegador.TabIndex = 268;
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
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblProcesando);
            this.panel3.Controls.Add(this.pbProgress);
            this.panel3.Controls.Add(this.wbNavegador);
            this.panel3.Location = new System.Drawing.Point(5, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1207, 457);
            this.panel3.TabIndex = 285;
            // 
            // frmReporteComprasVarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel3);
            this.Name = "frmReporteComprasVarias";
            this.Text = "Reporte Compras Varias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReporteComprasVarias_FormClosing);
            this.Load += new System.EventHandler(this.frmReporteComprasVarias_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFlag;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSucursales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Panel panel3;
    }
}