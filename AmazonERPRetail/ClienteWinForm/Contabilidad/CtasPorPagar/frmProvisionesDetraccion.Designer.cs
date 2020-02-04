namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmProvisionesDetraccion
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpConstancia = new System.Windows.Forms.DateTimePicker();
            this.txtConstancia = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pnlDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label10);
            this.pnlDatos.Controls.Add(this.dtpConstancia);
            this.pnlDatos.Controls.Add(this.txtConstancia);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Location = new System.Drawing.Point(4, 4);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(318, 102);
            this.pnlDatos.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 13);
            this.label10.TabIndex = 304;
            this.label10.Text = "Fecha Constancia Detraccion";
            // 
            // dtpConstancia
            // 
            this.dtpConstancia.CustomFormat = "dd/MM/yyyy";
            this.dtpConstancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpConstancia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConstancia.Location = new System.Drawing.Point(165, 62);
            this.dtpConstancia.Name = "dtpConstancia";
            this.dtpConstancia.Size = new System.Drawing.Size(96, 20);
            this.dtpConstancia.TabIndex = 6;
            this.dtpConstancia.Value = new System.DateTime(2016, 3, 28, 15, 57, 31, 0);
            // 
            // txtConstancia
            // 
            this.txtConstancia.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtConstancia.BackColor = System.Drawing.Color.White;
            this.txtConstancia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConstancia.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtConstancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConstancia.Location = new System.Drawing.Point(151, 37);
            this.txtConstancia.Margin = new System.Windows.Forms.Padding(2);
            this.txtConstancia.Name = "txtConstancia";
            this.txtConstancia.Size = new System.Drawing.Size(143, 20);
            this.txtConstancia.TabIndex = 8;
            this.txtConstancia.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtConstancia.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 317;
            this.label9.Text = "N° Constancia Detraccion";
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(316, 20);
            this.labelDegradado2.TabIndex = 500;
            this.labelDegradado2.Text = "Datos";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProvisionesDetraccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 110);
            this.Controls.Add(this.pnlDatos);
            this.MaximizeBox = false;
            this.Name = "frmProvisionesDetraccion";
            this.Text = "Detracción";
            this.Load += new System.EventHandler(this.frmProvisionesDetraccion_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpConstancia;
        private ControlesWinForm.SuperTextBox txtConstancia;
        private System.Windows.Forms.Label label9;
        private MyLabelG.LabelDegradado labelDegradado2;
    }
}