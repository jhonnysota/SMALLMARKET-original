namespace ClienteWinForm.Contabilidad
{
    partial class frmDatosAuxiDocCC
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
            System.Windows.Forms.Label label7;
            this.pnlDocumento = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtNumDoc = new ControlesWinForm.SuperTextBox();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.txtAuxiliar = new ControlesWinForm.SuperTextBox();
            this.pnlCostos = new System.Windows.Forms.Panel();
            this.txtCCostos = new ControlesWinForm.SuperTextBox();
            this.btCentroC = new System.Windows.Forms.Button();
            this.txtDesCCostos = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlDocumento.SuspendLayout();
            this.pnlCostos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(291, 213);
            this.btCancelar.Size = new System.Drawing.Size(112, 27);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(167, 213);
            this.btAceptar.Size = new System.Drawing.Size(112, 27);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(540, 18);
            this.lblTitPnlBase.Text = "Auxiliar";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(554, 25);
            this.lblTituloPrincipal.Text = "Actualización";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(527, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtRuc);
            this.pnlBase.Controls.Add(this.txtAuxiliar);
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Enabled = false;
            this.pnlBase.Location = new System.Drawing.Point(6, 28);
            this.pnlBase.Size = new System.Drawing.Size(542, 58);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtAuxiliar, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRuc, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(12, 31);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(40, 13);
            label7.TabIndex = 253;
            label7.Text = "Auxiliar";
            // 
            // pnlDocumento
            // 
            this.pnlDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDocumento.Controls.Add(this.labelDegradado1);
            this.pnlDocumento.Controls.Add(this.cboDocumento);
            this.pnlDocumento.Controls.Add(this.label28);
            this.pnlDocumento.Controls.Add(this.label30);
            this.pnlDocumento.Controls.Add(this.txtNumDoc);
            this.pnlDocumento.Controls.Add(this.txtSerie);
            this.pnlDocumento.Enabled = false;
            this.pnlDocumento.Location = new System.Drawing.Point(6, 88);
            this.pnlDocumento.Name = "pnlDocumento";
            this.pnlDocumento.Size = new System.Drawing.Size(542, 58);
            this.pnlDocumento.TabIndex = 155;
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
            this.labelDegradado1.Size = new System.Drawing.Size(540, 18);
            this.labelDegradado1.TabIndex = 251;
            this.labelDegradado1.Text = "Documento";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDocumento
            // 
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.DropDownWidth = 216;
            this.cboDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(75, 27);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(216, 21);
            this.cboDocumento.TabIndex = 201;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(12, 31);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(62, 13);
            this.label28.TabIndex = 306;
            this.label28.Text = "Documento";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(299, 32);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 13);
            this.label30.TabIndex = 308;
            this.label30.Text = "N° Doc";
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumDoc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.Location = new System.Drawing.Point(395, 27);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(126, 20);
            this.txtNumDoc.TabIndex = 203;
            this.txtNumDoc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumDoc.TextoVacio = "<Descripcion>";
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(345, 27);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(47, 20);
            this.txtSerie.TabIndex = 202;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "<Descripcion>";
            // 
            // txtAuxiliar
            // 
            this.txtAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuxiliar.Location = new System.Drawing.Point(160, 27);
            this.txtAuxiliar.Name = "txtAuxiliar";
            this.txtAuxiliar.Size = new System.Drawing.Size(361, 20);
            this.txtAuxiliar.TabIndex = 254;
            this.txtAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtAuxiliar.TextoVacio = "<Descripcion>";
            this.txtAuxiliar.TextChanged += new System.EventHandler(this.txtAuxiliar_TextChanged);
            this.txtAuxiliar.Validating += new System.ComponentModel.CancelEventHandler(this.txtAuxiliar_Validating);
            // 
            // pnlCostos
            // 
            this.pnlCostos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCostos.Controls.Add(this.txtCCostos);
            this.pnlCostos.Controls.Add(this.btCentroC);
            this.pnlCostos.Controls.Add(this.txtDesCCostos);
            this.pnlCostos.Controls.Add(this.label27);
            this.pnlCostos.Controls.Add(this.labelDegradado2);
            this.pnlCostos.Enabled = false;
            this.pnlCostos.Location = new System.Drawing.Point(6, 148);
            this.pnlCostos.Name = "pnlCostos";
            this.pnlCostos.Size = new System.Drawing.Size(542, 58);
            this.pnlCostos.TabIndex = 201;
            // 
            // txtCCostos
            // 
            this.txtCCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCCostos.BackColor = System.Drawing.Color.White;
            this.txtCCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCostos.Location = new System.Drawing.Point(75, 26);
            this.txtCCostos.Name = "txtCCostos";
            this.txtCCostos.Size = new System.Drawing.Size(82, 20);
            this.txtCCostos.TabIndex = 1502;
            this.txtCCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCCostos.TextoVacio = "<Descripcion>";
            // 
            // btCentroC
            // 
            this.btCentroC.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCentroC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCentroC.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCentroC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCentroC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCentroC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCentroC.Location = new System.Drawing.Point(498, 27);
            this.btCentroC.Name = "btCentroC";
            this.btCentroC.Size = new System.Drawing.Size(22, 18);
            this.btCentroC.TabIndex = 1504;
            this.btCentroC.TabStop = false;
            this.btCentroC.UseVisualStyleBackColor = true;
            this.btCentroC.Click += new System.EventHandler(this.btCentroC_Click);
            // 
            // txtDesCCostos
            // 
            this.txtDesCCostos.BackColor = System.Drawing.Color.White;
            this.txtDesCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCCostos.Location = new System.Drawing.Point(160, 26);
            this.txtDesCCostos.Name = "txtDesCCostos";
            this.txtDesCCostos.ReadOnly = true;
            this.txtDesCCostos.Size = new System.Drawing.Size(336, 20);
            this.txtDesCCostos.TabIndex = 1501;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 30);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 13);
            this.label27.TabIndex = 1503;
            this.label27.Text = "C. Costos";
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
            this.labelDegradado2.Size = new System.Drawing.Size(540, 18);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.Text = "C.Costos";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.White;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(75, 27);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(82, 20);
            this.txtRuc.TabIndex = 255;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // frmDatosAuxiDocCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 251);
            this.Controls.Add(this.pnlCostos);
            this.Controls.Add(this.pnlDocumento);
            this.Name = "frmDatosAuxiDocCC";
            this.Text = "frmDatosAuxiDocCC";
            this.Load += new System.EventHandler(this.frmDatosAuxiDocCC_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlDocumento, 0);
            this.Controls.SetChildIndex(this.pnlCostos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlDocumento.ResumeLayout(false);
            this.pnlDocumento.PerformLayout();
            this.pnlCostos.ResumeLayout(false);
            this.pnlCostos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesWinForm.SuperTextBox txtAuxiliar;
        private System.Windows.Forms.Panel pnlDocumento;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel pnlCostos;
        private ControlesWinForm.SuperTextBox txtNumDoc;
        private ControlesWinForm.SuperTextBox txtSerie;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cboDocumento;
        private System.Windows.Forms.Label label28;
        private MyLabelG.LabelDegradado labelDegradado2;
        private ControlesWinForm.SuperTextBox txtCCostos;
        private System.Windows.Forms.Button btCentroC;
        private System.Windows.Forms.TextBox txtDesCCostos;
        private System.Windows.Forms.Label label27;
        private ControlesWinForm.SuperTextBox txtRuc;
    }
}