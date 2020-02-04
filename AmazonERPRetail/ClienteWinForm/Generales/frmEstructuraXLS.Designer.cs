namespace ClienteWinForm.Generales
{
    partial class frmEstructuraXLS
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboCampos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtFila = new ControlesWinForm.SuperTextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColumna = new ControlesWinForm.SuperTextBox();
            this.chkIncluir = new System.Windows.Forms.CheckBox();
            this.chkLectura = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 260;
            this.label2.Text = "Campos";
            // 
            // cboCampos
            // 
            this.cboCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampos.FormattingEnabled = true;
            this.cboCampos.Location = new System.Drawing.Point(54, 30);
            this.cboCampos.Margin = new System.Windows.Forms.Padding(2);
            this.cboCampos.Name = "cboCampos";
            this.cboCampos.Size = new System.Drawing.Size(147, 21);
            this.cboCampos.TabIndex = 4;
            this.cboCampos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCampos_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(54, 7);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(147, 21);
            this.cboTipo.TabIndex = 1;
            this.cboTipo.SelectionChangeCommitted += new System.EventHandler(this.cboTipo_SelectionChangeCommitted);
            this.cboTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipo_KeyPress);
            // 
            // txtFila
            // 
            this.txtFila.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFila.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFila.Location = new System.Drawing.Point(408, 8);
            this.txtFila.Name = "txtFila";
            this.txtFila.Size = new System.Drawing.Size(72, 20);
            this.txtFila.TabIndex = 3;
            this.txtFila.Text = "0";
            this.txtFila.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFila.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtFila.TextoVacio = "<Descripcion>";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(324, 12);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(52, 13);
            this.lblTitulo.TabIndex = 264;
            this.lblTitulo.Text = "Fila Excel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 266;
            this.label4.Text = "Columna Excel";
            // 
            // txtColumna
            // 
            this.txtColumna.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtColumna.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtColumna.Location = new System.Drawing.Point(408, 30);
            this.txtColumna.Name = "txtColumna";
            this.txtColumna.Size = new System.Drawing.Size(72, 20);
            this.txtColumna.TabIndex = 6;
            this.txtColumna.Text = "0";
            this.txtColumna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtColumna.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtColumna.TextoVacio = "<Descripcion>";
            // 
            // chkIncluir
            // 
            this.chkIncluir.AutoSize = true;
            this.chkIncluir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncluir.Location = new System.Drawing.Point(206, 33);
            this.chkIncluir.Name = "chkIncluir";
            this.chkIncluir.Size = new System.Drawing.Size(108, 17);
            this.chkIncluir.TabIndex = 5;
            this.chkIncluir.Text = "Incluir en Lectura";
            this.chkIncluir.UseVisualStyleBackColor = true;
            this.chkIncluir.CheckedChanged += new System.EventHandler(this.chkIncluir_CheckedChanged);
            // 
            // chkLectura
            // 
            this.chkLectura.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLectura.Location = new System.Drawing.Point(206, 10);
            this.chkLectura.Name = "chkLectura";
            this.chkLectura.Size = new System.Drawing.Size(108, 17);
            this.chkLectura.TabIndex = 2;
            this.chkLectura.Text = "Lectura Lineal";
            this.chkLectura.UseVisualStyleBackColor = true;
            this.chkLectura.CheckedChanged += new System.EventHandler(this.chkLectura_CheckedChanged);
            // 
            // frmEstructuraXLS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 59);
            this.Controls.Add(this.chkLectura);
            this.Controls.Add(this.chkIncluir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtColumna);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtFila);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCampos);
            this.MaximizeBox = false;
            this.Name = "frmEstructuraXLS";
            this.Text = "Estructura Excel";
            this.Load += new System.EventHandler(this.frmEstructuraXLS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCampos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private ControlesWinForm.SuperTextBox txtFila;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtColumna;
        private System.Windows.Forms.CheckBox chkIncluir;
        private System.Windows.Forms.CheckBox chkLectura;
    }
}