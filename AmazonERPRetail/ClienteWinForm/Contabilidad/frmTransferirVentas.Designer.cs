namespace ClienteWinForm.Contabilidad
{
    partial class frmTransferirVentas
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
            CalanderControl.Design.ColorPair colorPair1 = new CalanderControl.Design.ColorPair();
            CalanderControl.Design.ColorPair colorPair2 = new CalanderControl.Design.ColorPair();
            CalanderControl.Design.ColorPair colorPair3 = new CalanderControl.Design.ColorPair();
            CalanderControl.Design.ColorPair colorPair4 = new CalanderControl.Design.ColorPair();
            this.mcInicio = new CalanderControl.MonthCalander();
            this.txtFecInicio = new System.Windows.Forms.TextBox();
            this.mcFinal = new CalanderControl.MonthCalander();
            this.txtFecFinal = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.btAceptar = new System.Windows.Forms.Button();
            this.mcInicio.SuspendLayout();
            this.mcFinal.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // mcInicio
            // 
            this.mcInicio.Appearance.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
            this.mcInicio.Appearance.ArrowHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            colorPair1.BackColor1 = System.Drawing.SystemColors.Control;
            colorPair1.BackColor2 = System.Drawing.SystemColors.Control;
            colorPair1.Gradient = 0;
            this.mcInicio.Appearance.CaptionBackColor = colorPair1;
            this.mcInicio.Appearance.CaptionTextColor = System.Drawing.SystemColors.ControlText;
            this.mcInicio.Appearance.ControlBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.mcInicio.Appearance.ControlBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.mcInicio.Appearance.DateDaySaperatorColor = System.Drawing.SystemColors.ControlLightLight;
            this.mcInicio.Appearance.DayMarker = System.Drawing.Color.Black;
            this.mcInicio.Appearance.DisabledMask = System.Drawing.SystemColors.ControlDark;
            this.mcInicio.Appearance.HoverColor = System.Drawing.SystemColors.Highlight;
            this.mcInicio.Appearance.InactiveTextColor = System.Drawing.SystemColors.ControlDark;
            colorPair2.BackColor1 = System.Drawing.Color.Black;
            colorPair2.BackColor2 = System.Drawing.Color.Black;
            colorPair2.Gradient = 0;
            this.mcInicio.Appearance.SelectedBackColor = colorPair2;
            this.mcInicio.Appearance.SelectedDateTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.mcInicio.Appearance.TodayBorderColor = System.Drawing.SystemColors.Highlight;
            this.mcInicio.Appearance.TodayColor = System.Drawing.SystemColors.ControlDark;
            this.mcInicio.Controls.Add(this.txtFecInicio);
            this.mcInicio.Location = new System.Drawing.Point(9, 29);
            this.mcInicio.Name = "mcInicio";
            this.mcInicio.Size = new System.Drawing.Size(164, 152);
            this.mcInicio.TabIndex = 0;
            this.mcInicio.ThemeProperty.ColorScheme = CalanderControl.Design.ColorScheme.Blue;
            this.mcInicio.ThemeProperty.UseTheme = false;
            // 
            // txtFecInicio
            // 
            this.txtFecInicio.BackColor = System.Drawing.SystemColors.Control;
            this.txtFecInicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecInicio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.txtFecInicio.ForeColor = System.Drawing.Color.Black;
            this.txtFecInicio.Location = new System.Drawing.Point(4, 136);
            this.txtFecInicio.Name = "txtFecInicio";
            this.txtFecInicio.Size = new System.Drawing.Size(156, 13);
            this.txtFecInicio.TabIndex = 363;
            this.txtFecInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mcFinal
            // 
            this.mcFinal.Appearance.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
            this.mcFinal.Appearance.ArrowHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            colorPair3.BackColor1 = System.Drawing.SystemColors.Control;
            colorPair3.BackColor2 = System.Drawing.SystemColors.Control;
            colorPair3.Gradient = 0;
            this.mcFinal.Appearance.CaptionBackColor = colorPair3;
            this.mcFinal.Appearance.CaptionTextColor = System.Drawing.SystemColors.ControlText;
            this.mcFinal.Appearance.ControlBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.mcFinal.Appearance.ControlBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.mcFinal.Appearance.DateDaySaperatorColor = System.Drawing.SystemColors.ControlLightLight;
            this.mcFinal.Appearance.DayMarker = System.Drawing.Color.Black;
            this.mcFinal.Appearance.DisabledMask = System.Drawing.SystemColors.ControlDark;
            this.mcFinal.Appearance.HoverColor = System.Drawing.SystemColors.Highlight;
            this.mcFinal.Appearance.InactiveTextColor = System.Drawing.SystemColors.ControlDark;
            colorPair4.BackColor1 = System.Drawing.Color.Black;
            colorPair4.BackColor2 = System.Drawing.Color.Black;
            this.mcFinal.Appearance.SelectedBackColor = colorPair4;
            this.mcFinal.Appearance.SelectedDateTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.mcFinal.Appearance.TodayBorderColor = System.Drawing.SystemColors.Highlight;
            this.mcFinal.Appearance.TodayColor = System.Drawing.SystemColors.ControlDark;
            this.mcFinal.Controls.Add(this.txtFecFinal);
            this.mcFinal.Location = new System.Drawing.Point(213, 29);
            this.mcFinal.Name = "mcFinal";
            this.mcFinal.Size = new System.Drawing.Size(164, 152);
            this.mcFinal.TabIndex = 1;
            this.mcFinal.ThemeProperty.ColorScheme = CalanderControl.Design.ColorScheme.OliveGreen;
            this.mcFinal.ThemeProperty.UseTheme = false;
            // 
            // txtFecFinal
            // 
            this.txtFecFinal.BackColor = System.Drawing.SystemColors.Control;
            this.txtFecFinal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecFinal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.txtFecFinal.ForeColor = System.Drawing.Color.Black;
            this.txtFecFinal.Location = new System.Drawing.Point(4, 136);
            this.txtFecFinal.Name = "txtFecFinal";
            this.txtFecFinal.Size = new System.Drawing.Size(156, 13);
            this.txtFecFinal.TabIndex = 364;
            this.txtFecFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.lblTitulo);
            this.panel6.Controls.Add(this.mcFinal);
            this.panel6.Controls.Add(this.mcInicio);
            this.panel6.Location = new System.Drawing.Point(5, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(388, 190);
            this.panel6.TabIndex = 290;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(185, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 362;
            this.label6.Text = "al";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(386, 21);
            this.lblTitulo.TabIndex = 249;
            this.lblTitulo.Text = "Periodos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::ClienteWinForm.Properties.Resources.Transferir;
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(136, 198);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(116, 27);
            this.btAceptar.TabIndex = 291;
            this.btAceptar.Text = "Transferir";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // frmTransferirVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.panel6);
            this.MaximizeBox = false;
            this.Name = "frmTransferirVentas";
            this.Text = "Transferir Ventas";
            this.Load += new System.EventHandler(this.frmTransferirVentas_Load);
            this.mcInicio.ResumeLayout(false);
            this.mcInicio.PerformLayout();
            this.mcFinal.ResumeLayout(false);
            this.mcFinal.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CalanderControl.MonthCalander mcInicio;
        private CalanderControl.MonthCalander mcFinal;
        private System.Windows.Forms.Panel panel6;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.Label label6;
        protected internal System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.TextBox txtFecInicio;
        private System.Windows.Forms.TextBox txtFecFinal;
    }
}