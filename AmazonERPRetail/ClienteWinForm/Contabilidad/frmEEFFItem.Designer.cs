namespace ClienteWinForm.Contabilidad
{
    partial class frmEEFFItem
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
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label31;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSecItem = new System.Windows.Forms.TextBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelDegradado9 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.cboTipoItem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoColumna = new System.Windows.Forms.ComboBox();
            this.cboTipoTabla = new System.Windows.Forms.ComboBox();
            this.cboTipoCaracteristica = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkMostrarValor = new System.Windows.Forms.CheckBox();
            this.chbEnviaExcel = new System.Windows.Forms.CheckBox();
            this.chbPorcentaje = new System.Windows.Forms.CheckBox();
            this.chbImprimir = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodSunat = new System.Windows.Forms.TextBox();
            this.txtidItem = new System.Windows.Forms.TextBox();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(523, 184);
            this.btCancelar.Size = new System.Drawing.Size(101, 26);
            this.btCancelar.TabIndex = 1;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(418, 184);
            this.btAceptar.Size = new System.Drawing.Size(101, 26);
            this.btAceptar.TabIndex = 0;
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(368, 22);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(654, 25);
            this.lblTituloPrincipal.Text = "EEFF ITEM";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(627, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtCodSunat);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.cboTipoCaracteristica);
            this.pnlBase.Controls.Add(this.cboTipoTabla);
            this.pnlBase.Controls.Add(this.cboTipoColumna);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.cboTipoItem);
            this.pnlBase.Controls.Add(this.txtDescrip);
            this.pnlBase.Controls.Add(this.txtSecItem);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.panel2);
            this.pnlBase.Location = new System.Drawing.Point(8, 29);
            this.pnlBase.Size = new System.Drawing.Size(370, 228);
            this.pnlBase.Controls.SetChildIndex(this.panel2, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSecItem, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDescrip, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoItem, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoColumna, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoTabla, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoCaracteristica, 0);
            this.pnlBase.Controls.SetChildIndex(this.label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodSunat, 0);
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(12, 104);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificacion";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(12, 81);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.Location = new System.Drawing.Point(12, 35);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(86, 13);
            label29.TabIndex = 0;
            label29.Text = "Usuario Registro";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(12, 58);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(79, 13);
            label31.TabIndex = 2;
            label31.Text = "Fecha Registro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 251;
            this.label1.Text = "Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 252;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 253;
            this.label3.Text = "Tabla";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 254;
            this.label4.Text = "Caracteristica";
            // 
            // txtSecItem
            // 
            this.txtSecItem.Location = new System.Drawing.Point(91, 29);
            this.txtSecItem.MaxLength = 20;
            this.txtSecItem.Name = "txtSecItem";
            this.txtSecItem.Size = new System.Drawing.Size(121, 20);
            this.txtSecItem.TabIndex = 0;
            this.txtSecItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecItem_KeyPress);
            // 
            // txtDescrip
            // 
            this.txtDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescrip.Location = new System.Drawing.Point(91, 51);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(271, 20);
            this.txtDescrip.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.labelDegradado9);
            this.panel8.Controls.Add(label24);
            this.panel8.Controls.Add(this.txtFechaModificacion);
            this.panel8.Controls.Add(this.txtUsuRegistro);
            this.panel8.Controls.Add(label25);
            this.panel8.Controls.Add(label29);
            this.panel8.Controls.Add(this.txtUsuModificacion);
            this.panel8.Controls.Add(this.txtFechaRegistro);
            this.panel8.Controls.Add(label31);
            this.panel8.Location = new System.Drawing.Point(381, 30);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(265, 133);
            this.panel8.TabIndex = 263;
            // 
            // labelDegradado9
            // 
            this.labelDegradado9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado9.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado9.ForeColor = System.Drawing.Color.White;
            this.labelDegradado9.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado9.Name = "labelDegradado9";
            this.labelDegradado9.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado9.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado9.Size = new System.Drawing.Size(263, 21);
            this.labelDegradado9.TabIndex = 253;
            this.labelDegradado9.Text = "Auditoria";
            this.labelDegradado9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(120, 99);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(129, 21);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(120, 30);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(129, 21);
            this.txtUsuRegistro.TabIndex = 1;
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(120, 76);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(129, 21);
            this.txtUsuModificacion.TabIndex = 5;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(120, 53);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(129, 21);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // cboTipoItem
            // 
            this.cboTipoItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoItem.DropDownWidth = 110;
            this.cboTipoItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoItem.FormattingEnabled = true;
            this.cboTipoItem.Location = new System.Drawing.Point(91, 74);
            this.cboTipoItem.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoItem.Name = "cboTipoItem";
            this.cboTipoItem.Size = new System.Drawing.Size(271, 21);
            this.cboTipoItem.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 264;
            this.label5.Text = "Tipo";
            // 
            // cboTipoColumna
            // 
            this.cboTipoColumna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoColumna.DropDownWidth = 110;
            this.cboTipoColumna.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoColumna.FormattingEnabled = true;
            this.cboTipoColumna.Location = new System.Drawing.Point(91, 143);
            this.cboTipoColumna.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoColumna.Name = "cboTipoColumna";
            this.cboTipoColumna.Size = new System.Drawing.Size(121, 21);
            this.cboTipoColumna.TabIndex = 5;
            // 
            // cboTipoTabla
            // 
            this.cboTipoTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTabla.DropDownWidth = 110;
            this.cboTipoTabla.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoTabla.FormattingEnabled = true;
            this.cboTipoTabla.Location = new System.Drawing.Point(91, 97);
            this.cboTipoTabla.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoTabla.Name = "cboTipoTabla";
            this.cboTipoTabla.Size = new System.Drawing.Size(121, 21);
            this.cboTipoTabla.TabIndex = 3;
            // 
            // cboTipoCaracteristica
            // 
            this.cboTipoCaracteristica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCaracteristica.DropDownWidth = 110;
            this.cboTipoCaracteristica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCaracteristica.FormattingEnabled = true;
            this.cboTipoCaracteristica.Location = new System.Drawing.Point(91, 120);
            this.cboTipoCaracteristica.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoCaracteristica.Name = "cboTipoCaracteristica";
            this.cboTipoCaracteristica.Size = new System.Drawing.Size(121, 21);
            this.cboTipoCaracteristica.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 268;
            this.label6.Text = "Valor Excel";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkMostrarValor);
            this.panel2.Controls.Add(this.chbEnviaExcel);
            this.panel2.Controls.Add(this.chbPorcentaje);
            this.panel2.Controls.Add(this.chbImprimir);
            this.panel2.Location = new System.Drawing.Point(7, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 29);
            this.panel2.TabIndex = 269;
            // 
            // chkMostrarValor
            // 
            this.chkMostrarValor.AutoSize = true;
            this.chkMostrarValor.Location = new System.Drawing.Point(256, 6);
            this.chkMostrarValor.Name = "chkMostrarValor";
            this.chkMostrarValor.Size = new System.Drawing.Size(88, 17);
            this.chkMostrarValor.TabIndex = 12;
            this.chkMostrarValor.Text = "Mostrar Valor";
            this.chkMostrarValor.UseVisualStyleBackColor = true;
            // 
            // chbEnviaExcel
            // 
            this.chbEnviaExcel.AutoSize = true;
            this.chbEnviaExcel.Location = new System.Drawing.Point(165, 6);
            this.chbEnviaExcel.Name = "chbEnviaExcel";
            this.chbEnviaExcel.Size = new System.Drawing.Size(85, 17);
            this.chbEnviaExcel.TabIndex = 11;
            this.chbEnviaExcel.Text = "Enviar Excel";
            this.chbEnviaExcel.UseVisualStyleBackColor = true;
            // 
            // chbPorcentaje
            // 
            this.chbPorcentaje.AutoSize = true;
            this.chbPorcentaje.Location = new System.Drawing.Point(78, 6);
            this.chbPorcentaje.Name = "chbPorcentaje";
            this.chbPorcentaje.Size = new System.Drawing.Size(77, 17);
            this.chbPorcentaje.TabIndex = 10;
            this.chbPorcentaje.Text = "Porcentaje";
            this.chbPorcentaje.UseVisualStyleBackColor = true;
            // 
            // chbImprimir
            // 
            this.chbImprimir.AutoSize = true;
            this.chbImprimir.Location = new System.Drawing.Point(13, 6);
            this.chbImprimir.Name = "chbImprimir";
            this.chbImprimir.Size = new System.Drawing.Size(61, 17);
            this.chbImprimir.TabIndex = 9;
            this.chbImprimir.Text = "Imprimir";
            this.chbImprimir.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 264;
            this.label7.Text = "Cod.Sunat";
            // 
            // txtCodSunat
            // 
            this.txtCodSunat.Location = new System.Drawing.Point(91, 167);
            this.txtCodSunat.MaxLength = 20;
            this.txtCodSunat.Name = "txtCodSunat";
            this.txtCodSunat.Size = new System.Drawing.Size(121, 20);
            this.txtCodSunat.TabIndex = 264;
            // 
            // txtidItem
            // 
            this.txtidItem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtidItem.Enabled = false;
            this.txtidItem.Location = new System.Drawing.Point(89, 59);
            this.txtidItem.MaxLength = 20;
            this.txtidItem.Name = "txtidItem";
            this.txtidItem.Size = new System.Drawing.Size(10, 20);
            this.txtidItem.TabIndex = 264;
            this.txtidItem.Visible = false;
            // 
            // frmEEFFItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 260);
            this.Controls.Add(this.txtidItem);
            this.Controls.Add(this.panel8);
            this.Name = "frmEEFFItem";
            this.Text = "frmEEFFItem";
            this.Load += new System.EventHandler(this.frmEEFFItem_Load);
            this.Shown += new System.EventHandler(this.frmEEFFItem_Shown);
            this.Controls.SetChildIndex(this.panel8, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.txtidItem, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtSecItem;
        private System.Windows.Forms.Panel panel8;
        private MyLabelG.LabelDegradado labelDegradado9;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipoItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoCaracteristica;
        private System.Windows.Forms.ComboBox cboTipoTabla;
        private System.Windows.Forms.ComboBox cboTipoColumna;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chbEnviaExcel;
        private System.Windows.Forms.CheckBox chbPorcentaje;
        private System.Windows.Forms.CheckBox chbImprimir;
        private System.Windows.Forms.CheckBox chkMostrarValor;
        private System.Windows.Forms.TextBox txtCodSunat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtidItem;
    }
}