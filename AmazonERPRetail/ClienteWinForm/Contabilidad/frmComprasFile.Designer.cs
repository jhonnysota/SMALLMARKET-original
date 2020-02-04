namespace ClienteWinForm.Contabilidad
{
    partial class frmComprasFile
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
            System.Windows.Forms.Label idComprobanteLabel;
            System.Windows.Forms.Label numFileLabel;
            System.Windows.Forms.Label label1;
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.chkOc = new System.Windows.Forms.CheckBox();
            this.chkCtaCte = new System.Windows.Forms.CheckBox();
            this.chkIgv = new System.Windows.Forms.CheckBox();
            this.cboCoIgv = new System.Windows.Forms.ComboBox();
            this.cboCoVen = new System.Windows.Forms.ComboBox();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.chkOp = new System.Windows.Forms.CheckBox();
            idComprobanteLabel = new System.Windows.Forms.Label();
            numFileLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // idComprobanteLabel
            // 
            idComprobanteLabel.AutoSize = true;
            idComprobanteLabel.Location = new System.Drawing.Point(6, 51);
            idComprobanteLabel.Name = "idComprobanteLabel";
            idComprobanteLabel.Size = new System.Drawing.Size(30, 13);
            idComprobanteLabel.TabIndex = 316;
            idComprobanteLabel.Text = "Libro";
            // 
            // numFileLabel
            // 
            numFileLabel.AutoSize = true;
            numFileLabel.Location = new System.Drawing.Point(6, 74);
            numFileLabel.Name = "numFileLabel";
            numFileLabel.Size = new System.Drawing.Size(23, 13);
            numFileLabel.TabIndex = 317;
            numFileLabel.Text = "File";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 97);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 13);
            label1.TabIndex = 320;
            label1.Text = "Tip.Col. Compra";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.chkOp);
            this.pnlDatos.Controls.Add(this.chkOc);
            this.pnlDatos.Controls.Add(this.chkCtaCte);
            this.pnlDatos.Controls.Add(this.chkIgv);
            this.pnlDatos.Controls.Add(this.cboCoIgv);
            this.pnlDatos.Controls.Add(this.cboCoVen);
            this.pnlDatos.Controls.Add(label1);
            this.pnlDatos.Controls.Add(this.cboFile);
            this.pnlDatos.Controls.Add(this.cboLibro);
            this.pnlDatos.Controls.Add(idComprobanteLabel);
            this.pnlDatos.Controls.Add(numFileLabel);
            this.pnlDatos.Controls.Add(this.txtDescripcion);
            this.pnlDatos.Controls.Add(this.label10);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(325, 169);
            this.pnlDatos.TabIndex = 137;
            this.pnlDatos.TabStop = true;
            // 
            // chkOc
            // 
            this.chkOc.AutoSize = true;
            this.chkOc.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chkOc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkOc.Location = new System.Drawing.Point(132, 143);
            this.chkOc.Name = "chkOc";
            this.chkOc.Size = new System.Drawing.Size(81, 17);
            this.chkOc.TabIndex = 326;
            this.chkOc.Text = "Afecta O.C.";
            this.chkOc.UseVisualStyleBackColor = false;
            // 
            // chkCtaCte
            // 
            this.chkCtaCte.AutoSize = true;
            this.chkCtaCte.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chkCtaCte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCtaCte.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCtaCte.Location = new System.Drawing.Point(53, 143);
            this.chkCtaCte.Name = "chkCtaCte";
            this.chkCtaCte.Size = new System.Drawing.Size(67, 17);
            this.chkCtaCte.TabIndex = 325;
            this.chkCtaCte.Text = "Cta. Cte.";
            this.chkCtaCte.UseVisualStyleBackColor = false;
            // 
            // chkIgv
            // 
            this.chkIgv.AutoSize = true;
            this.chkIgv.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chkIgv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIgv.Location = new System.Drawing.Point(6, 118);
            this.chkIgv.Name = "chkIgv";
            this.chkIgv.Size = new System.Drawing.Size(62, 17);
            this.chkIgv.TabIndex = 324;
            this.chkIgv.Text = "Col. Igv";
            this.chkIgv.UseVisualStyleBackColor = false;
            this.chkIgv.CheckedChanged += new System.EventHandler(this.chkIgv_CheckedChanged);
            // 
            // cboCoIgv
            // 
            this.cboCoIgv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoIgv.Enabled = false;
            this.cboCoIgv.FormattingEnabled = true;
            this.cboCoIgv.Location = new System.Drawing.Point(90, 116);
            this.cboCoIgv.Name = "cboCoIgv";
            this.cboCoIgv.Size = new System.Drawing.Size(222, 21);
            this.cboCoIgv.TabIndex = 322;
            // 
            // cboCoVen
            // 
            this.cboCoVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoVen.FormattingEnabled = true;
            this.cboCoVen.Location = new System.Drawing.Point(90, 93);
            this.cboCoVen.Name = "cboCoVen";
            this.cboCoVen.Size = new System.Drawing.Size(222, 21);
            this.cboCoVen.TabIndex = 321;
            // 
            // cboFile
            // 
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(90, 70);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(222, 21);
            this.cboFile.TabIndex = 319;
            // 
            // cboLibro
            // 
            this.cboLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Location = new System.Drawing.Point(90, 47);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(222, 21);
            this.cboLibro.TabIndex = 318;
            this.cboLibro.SelectionChangeCommitted += new System.EventHandler(this.cboLibro_SelectionChangeCommitted);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(90, 24);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(222, 20);
            this.txtDescripcion.TabIndex = 102;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 304;
            this.label10.Text = "Descripción";
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
            this.labelDegradado2.Size = new System.Drawing.Size(323, 17);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "Principales";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado5);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(330, 3);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(265, 134);
            this.pnlAuditoria.TabIndex = 138;
            // 
            // labelDegradado5
            // 
            this.labelDegradado5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado5.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado5.ForeColor = System.Drawing.Color.White;
            this.labelDegradado5.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado5.Name = "labelDegradado5";
            this.labelDegradado5.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado5.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado5.Size = new System.Drawing.Size(263, 17);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Auditoria";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(10, 100);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(117, 96);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(135, 20);
            this.txtModifica.TabIndex = 0;
            this.txtModifica.TabStop = false;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(117, 54);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(135, 20);
            this.txtRegistro.TabIndex = 0;
            this.txtRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(117, 33);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(135, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(117, 75);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(135, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // chkOp
            // 
            this.chkOp.AutoSize = true;
            this.chkOp.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chkOp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkOp.Location = new System.Drawing.Point(226, 143);
            this.chkOp.Name = "chkOp";
            this.chkOp.Size = new System.Drawing.Size(85, 17);
            this.chkOp.TabIndex = 327;
            this.chkOp.Text = "Mostrar O.P.";
            this.chkOp.UseVisualStyleBackColor = false;
            // 
            // frmComprasFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 175);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlAuditoria);
            this.MaximizeBox = false;
            this.Name = "frmComprasFile";
            this.Text = "Compras File";
            this.Load += new System.EventHandler(this.frmComprasFile_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.Label label10;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.ComboBox cboCoVen;
        private System.Windows.Forms.ComboBox cboCoIgv;
        private System.Windows.Forms.CheckBox chkIgv;
        private System.Windows.Forms.CheckBox chkCtaCte;
        private System.Windows.Forms.CheckBox chkOc;
        private System.Windows.Forms.CheckBox chkOp;
    }
}