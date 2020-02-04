namespace ClienteWinForm.Busquedas
{
    partial class frmTipoCambioSunat
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
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.cboMeses = new System.Windows.Forms.ComboBox();
            this.cboAnios = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTipoCambio = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.btGuardar = new System.Windows.Forms.Button();
            this.btExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoCambio)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(328, 547);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(128, 24);
            this.btCancelar.TabIndex = 260;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Visible = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAceptar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(189, 547);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(128, 24);
            this.btAceptar.TabIndex = 259;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Visible = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.buscar_16x16neg;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.Location = new System.Drawing.Point(379, 514);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(97, 25);
            this.btBuscar.TabIndex = 258;
            this.btBuscar.Text = "Consultar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // cboMeses
            // 
            this.cboMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(157, 517);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(103, 21);
            this.cboMeses.TabIndex = 257;
            // 
            // cboAnios
            // 
            this.cboAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnios.FormattingEnabled = true;
            this.cboAnios.Location = new System.Drawing.Point(298, 517);
            this.cboAnios.Name = "cboAnios";
            this.cboAnios.Size = new System.Drawing.Size(60, 21);
            this.cboAnios.TabIndex = 255;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(654, 13);
            this.label5.TabIndex = 253;
            this.label5.Text = "3.- Para efectos del Impuesto a la Renta, se deberá tomar el tipo de cambio de ci" +
    "erre, al 31 de Diciembre del ejercicio correspondiente.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(525, 13);
            this.label4.TabIndex = 252;
            this.label4.Text = "2.- En los días que no se cuente con tipo de cambio publicado, se deberá tomar el" +
    " del día inmediato anterior.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(456, 13);
            this.label3.TabIndex = 251;
            this.label3.Text = "1.- El tipo de cambio publicado corresponde a la cotización de cierre de la SBS d" +
    "el día anterior.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 250;
            this.label2.Text = "Notas:";
            // 
            // dgvTipoCambio
            // 
            this.dgvTipoCambio.AllowUserToAddRows = false;
            this.dgvTipoCambio.AllowUserToDeleteRows = false;
            this.dgvTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTipoCambio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoCambio.EnableHeadersVisualStyles = false;
            this.dgvTipoCambio.Location = new System.Drawing.Point(60, 66);
            this.dgvTipoCambio.Name = "dgvTipoCambio";
            this.dgvTipoCambio.Size = new System.Drawing.Size(542, 367);
            this.dgvTipoCambio.TabIndex = 249;
            this.dgvTipoCambio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipoCambio_CellDoubleClick);
            this.dgvTipoCambio.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTipoCambio_CellFormatting);
            this.dgvTipoCambio.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvTipoCambio_ColumnAdded);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(542, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de cambio publicado al : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.Location = new System.Drawing.Point(287, 8);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(54, 14);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Periodo";
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.Color.White;
            this.btGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.Image = global::ClienteWinForm.Properties.Resources.guardar_16x16neg;
            this.btGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGuardar.Location = new System.Drawing.Point(189, 547);
            this.btGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(128, 24);
            this.btGuardar.TabIndex = 261;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Visible = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // btExportar
            // 
            this.btExportar.BackColor = System.Drawing.Color.White;
            this.btExportar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExportar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportar.Image = global::ClienteWinForm.Properties.Resources.exportar_24x24neg;
            this.btExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExportar.Location = new System.Drawing.Point(328, 547);
            this.btExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(128, 24);
            this.btExportar.TabIndex = 262;
            this.btExportar.Text = "Exportar PDB";
            this.btExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExportar.UseVisualStyleBackColor = false;
            this.btExportar.Visible = false;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // frmTipoCambioSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(666, 577);
            this.Controls.Add(this.btExportar);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.cboMeses);
            this.Controls.Add(this.cboAnios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTipoCambio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPeriodo);
            this.MaximizeBox = false;
            this.Name = "frmTipoCambioSunat";
            this.Text = "Tipo de Cambio - Sunat";
            this.Load += new System.EventHandler(this.frmTipoCambioSunat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoCambio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTipoCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMeses;
        private System.Windows.Forms.ComboBox cboAnios;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Button btExportar;
    }
}