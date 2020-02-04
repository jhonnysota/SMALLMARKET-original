namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmDetalleReparable
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
            this.pnlReparable = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRefRepa = new ControlesWinForm.SuperTextBox();
            this.cboConceptoReparable = new System.Windows.Forms.ComboBox();
            this.cboReparable = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.labelDegradado10 = new MyLabelG.LabelDegradado();
            this.btAceptar = new System.Windows.Forms.Button();
            this.pnlReparable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReparable
            // 
            this.pnlReparable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReparable.Controls.Add(this.label3);
            this.pnlReparable.Controls.Add(this.txtRefRepa);
            this.pnlReparable.Controls.Add(this.cboConceptoReparable);
            this.pnlReparable.Controls.Add(this.cboReparable);
            this.pnlReparable.Controls.Add(this.label16);
            this.pnlReparable.Controls.Add(this.labelDegradado10);
            this.pnlReparable.Location = new System.Drawing.Point(3, 4);
            this.pnlReparable.Name = "pnlReparable";
            this.pnlReparable.Size = new System.Drawing.Size(266, 128);
            this.pnlReparable.TabIndex = 1101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 330;
            this.label3.Text = "Tipo";
            // 
            // txtRefRepa
            // 
            this.txtRefRepa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRefRepa.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRefRepa.ColorTextoVacio = System.Drawing.Color.SlateGray;
            this.txtRefRepa.Enabled = false;
            this.txtRefRepa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefRepa.Location = new System.Drawing.Point(12, 69);
            this.txtRefRepa.Multiline = true;
            this.txtRefRepa.Name = "txtRefRepa";
            this.txtRefRepa.Size = new System.Drawing.Size(241, 53);
            this.txtRefRepa.TabIndex = 1103;
            this.txtRefRepa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRefRepa.TextoVacio = "INGRESE REFERENCIA";
            // 
            // cboConceptoReparable
            // 
            this.cboConceptoReparable.BackColor = System.Drawing.Color.White;
            this.cboConceptoReparable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptoReparable.Enabled = false;
            this.cboConceptoReparable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConceptoReparable.FormattingEnabled = true;
            this.cboConceptoReparable.Location = new System.Drawing.Point(64, 46);
            this.cboConceptoReparable.Name = "cboConceptoReparable";
            this.cboConceptoReparable.Size = new System.Drawing.Size(189, 21);
            this.cboConceptoReparable.TabIndex = 1102;
            // 
            // cboReparable
            // 
            this.cboReparable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReparable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReparable.FormattingEnabled = true;
            this.cboReparable.Location = new System.Drawing.Point(64, 23);
            this.cboReparable.Name = "cboReparable";
            this.cboReparable.Size = new System.Drawing.Size(189, 21);
            this.cboReparable.TabIndex = 1101;
            this.cboReparable.SelectionChangeCommitted += new System.EventHandler(this.cboReparable_SelectionChangeCommitted);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 326;
            this.label16.Text = "Concepto";
            // 
            // labelDegradado10
            // 
            this.labelDegradado10.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado10.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado10.ForeColor = System.Drawing.Color.White;
            this.labelDegradado10.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado10.Name = "labelDegradado10";
            this.labelDegradado10.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado10.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado10.Size = new System.Drawing.Size(264, 18);
            this.labelDegradado10.TabIndex = 253;
            this.labelDegradado10.Text = "Reparable/Boleta";
            this.labelDegradado10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btAceptar.Location = new System.Drawing.Point(80, 136);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(112, 23);
            this.btAceptar.TabIndex = 1102;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // frmDetalleReparable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(272, 163);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnlReparable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetalleReparable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Es Reparable";
            this.Load += new System.EventHandler(this.frmDetalleReparable_Load);
            this.pnlReparable.ResumeLayout(false);
            this.pnlReparable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReparable;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtRefRepa;
        private System.Windows.Forms.ComboBox cboConceptoReparable;
        private System.Windows.Forms.ComboBox cboReparable;
        private System.Windows.Forms.Label label16;
        private MyLabelG.LabelDegradado labelDegradado10;
        protected internal System.Windows.Forms.Button btAceptar;
    }
}