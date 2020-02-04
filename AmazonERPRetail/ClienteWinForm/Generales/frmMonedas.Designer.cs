namespace ClienteWinForm.Generales
{
    partial class frmMonedas
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
            System.Windows.Forms.Label desAbreviaturaLabel;
            System.Windows.Forms.Label desMonedaLabel;
            System.Windows.Forms.Label fechaModificaLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label idMonedaLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label label1;
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIso = new System.Windows.Forms.TextBox();
            this.txtAbreviatura = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtIdMoneda = new System.Windows.Forms.TextBox();
            this.bsDatos = new System.Windows.Forms.BindingSource(this.components);
            this.txtFecMod = new System.Windows.Forms.TextBox();
            this.txtFecReg = new System.Windows.Forms.TextBox();
            this.txtUsuMod = new System.Windows.Forms.TextBox();
            this.txtUsuReg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvMonedas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsListado = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            desAbreviaturaLabel = new System.Windows.Forms.Label();
            desMonedaLabel = new System.Windows.Forms.Label();
            fechaModificaLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            idMonedaLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonedas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).BeginInit();
            this.SuspendLayout();
            // 
            // desAbreviaturaLabel
            // 
            desAbreviaturaLabel.AutoSize = true;
            desAbreviaturaLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            desAbreviaturaLabel.Location = new System.Drawing.Point(11, 82);
            desAbreviaturaLabel.Name = "desAbreviaturaLabel";
            desAbreviaturaLabel.Size = new System.Drawing.Size(64, 13);
            desAbreviaturaLabel.TabIndex = 97;
            desAbreviaturaLabel.Text = "Abreviatura";
            // 
            // desMonedaLabel
            // 
            desMonedaLabel.AutoSize = true;
            desMonedaLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            desMonedaLabel.Location = new System.Drawing.Point(11, 59);
            desMonedaLabel.Name = "desMonedaLabel";
            desMonedaLabel.Size = new System.Drawing.Size(61, 13);
            desMonedaLabel.TabIndex = 99;
            desMonedaLabel.Text = "Descripción";
            // 
            // fechaModificaLabel
            // 
            fechaModificaLabel.AutoSize = true;
            fechaModificaLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificaLabel.Location = new System.Drawing.Point(23, 99);
            fechaModificaLabel.Name = "fechaModificaLabel";
            fechaModificaLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificaLabel.TabIndex = 101;
            fechaModificaLabel.Text = "Fecha Modificación";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(23, 55);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 103;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // idMonedaLabel
            // 
            idMonedaLabel.AutoSize = true;
            idMonedaLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idMonedaLabel.Location = new System.Drawing.Point(11, 36);
            idMonedaLabel.Name = "idMonedaLabel";
            idMonedaLabel.Size = new System.Drawing.Size(71, 13);
            idMonedaLabel.TabIndex = 105;
            idMonedaLabel.Text = "Cód. Moneda";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(23, 77);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 107;
            usuarioModificacionLabel.Text = "Usuario Modificación";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(23, 33);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistroLabel.TabIndex = 109;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(173, 82);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 255;
            label1.Text = "ISO 4217";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(label1);
            this.panel2.Controls.Add(this.txtIso);
            this.panel2.Controls.Add(desAbreviaturaLabel);
            this.panel2.Controls.Add(this.txtAbreviatura);
            this.panel2.Controls.Add(desMonedaLabel);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(idMonedaLabel);
            this.panel2.Controls.Add(this.txtIdMoneda);
            this.panel2.Location = new System.Drawing.Point(349, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 114);
            this.panel2.TabIndex = 35;
            // 
            // txtIso
            // 
            this.txtIso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIso.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIso.Location = new System.Drawing.Point(229, 78);
            this.txtIso.Name = "txtIso";
            this.txtIso.Size = new System.Drawing.Size(69, 20);
            this.txtIso.TabIndex = 254;
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAbreviatura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbreviatura.Location = new System.Drawing.Point(89, 78);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Size = new System.Drawing.Size(78, 20);
            this.txtAbreviatura.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(89, 55);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(209, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // txtIdMoneda
            // 
            this.txtIdMoneda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdMoneda.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdMoneda.Location = new System.Drawing.Point(89, 32);
            this.txtIdMoneda.Name = "txtIdMoneda";
            this.txtIdMoneda.Size = new System.Drawing.Size(57, 20);
            this.txtIdMoneda.TabIndex = 106;
            // 
            // bsDatos
            // 
            this.bsDatos.DataSource = typeof(Entidades.Generales.MonedasE);
            // 
            // txtFecMod
            // 
            this.txtFecMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecMod.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecMod.Location = new System.Drawing.Point(130, 95);
            this.txtFecMod.Name = "txtFecMod";
            this.txtFecMod.ReadOnly = true;
            this.txtFecMod.Size = new System.Drawing.Size(148, 20);
            this.txtFecMod.TabIndex = 102;
            // 
            // txtFecReg
            // 
            this.txtFecReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecReg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecReg.Location = new System.Drawing.Point(130, 51);
            this.txtFecReg.Name = "txtFecReg";
            this.txtFecReg.ReadOnly = true;
            this.txtFecReg.Size = new System.Drawing.Size(148, 20);
            this.txtFecReg.TabIndex = 104;
            // 
            // txtUsuMod
            // 
            this.txtUsuMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuMod.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuMod.Location = new System.Drawing.Point(130, 73);
            this.txtUsuMod.Name = "txtUsuMod";
            this.txtUsuMod.ReadOnly = true;
            this.txtUsuMod.Size = new System.Drawing.Size(148, 20);
            this.txtUsuMod.TabIndex = 108;
            // 
            // txtUsuReg
            // 
            this.txtUsuReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuReg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuReg.Location = new System.Drawing.Point(130, 29);
            this.txtUsuReg.Name = "txtUsuReg";
            this.txtUsuReg.ReadOnly = true;
            this.txtUsuReg.Size = new System.Drawing.Size(148, 20);
            this.txtUsuReg.TabIndex = 110;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtUsuReg);
            this.panel1.Controls.Add(usuarioRegistroLabel);
            this.panel1.Controls.Add(fechaRegistroLabel);
            this.panel1.Controls.Add(fechaModificaLabel);
            this.panel1.Controls.Add(this.txtFecReg);
            this.panel1.Controls.Add(this.txtFecMod);
            this.panel1.Controls.Add(this.txtUsuMod);
            this.panel1.Controls.Add(usuarioModificacionLabel);
            this.panel1.Location = new System.Drawing.Point(349, 121);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 126);
            this.panel1.TabIndex = 36;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvMonedas);
            this.panel3.Controls.Add(this.lblRegistro);
            this.panel3.Location = new System.Drawing.Point(5, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 243);
            this.panel3.TabIndex = 98;
            // 
            // dgvMonedas
            // 
            this.dgvMonedas.AllowUserToAddRows = false;
            this.dgvMonedas.AllowUserToDeleteRows = false;
            this.dgvMonedas.AutoGenerateColumns = false;
            this.dgvMonedas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMonedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonedas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.ISO});
            this.dgvMonedas.DataSource = this.bsListado;
            this.dgvMonedas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonedas.EnableHeadersVisualStyles = false;
            this.dgvMonedas.Location = new System.Drawing.Point(0, 18);
            this.dgvMonedas.Name = "dgvMonedas";
            this.dgvMonedas.ReadOnly = true;
            this.dgvMonedas.RowTemplate.Height = 24;
            this.dgvMonedas.Size = new System.Drawing.Size(338, 223);
            this.dgvMonedas.TabIndex = 97;
            this.dgvMonedas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonedas_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idMoneda";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "desMoneda";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "desAbreviatura";
            this.dataGridViewTextBoxColumn3.HeaderText = "Abreviatura";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn4.HeaderText = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FechaRegistro";
            this.dataGridViewTextBoxColumn5.HeaderText = "FechaRegistro";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn6.HeaderText = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FechaModifica";
            this.dataGridViewTextBoxColumn7.HeaderText = "FechaModifica";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // ISO
            // 
            this.ISO.DataPropertyName = "ISO";
            this.ISO.HeaderText = "ISO";
            this.ISO.Name = "ISO";
            this.ISO.ReadOnly = true;
            this.ISO.Visible = false;
            // 
            // bsListado
            // 
            this.bsListado.DataSource = typeof(Entidades.Generales.MonedasE);
            this.bsListado.CurrentChanged += new System.EventHandler(this.bsListado_CurrentChanged);
            // 
            // lblRegistro
            // 
            this.lblRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistro.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.Location = new System.Drawing.Point(0, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(338, 18);
            this.lblRegistro.TabIndex = 429;
            this.lblRegistro.Text = "Registros";
            this.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 18);
            this.label2.TabIndex = 429;
            this.label2.Text = "Datos Principales";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 18);
            this.label6.TabIndex = 347;
            this.label6.Text = "Auditoria";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMonedas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(663, 250);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmMonedas";
            this.Text = "Monedas";
            this.Load += new System.EventHandler(this.frmMonedas_Load);
            this.Resize += new System.EventHandler(this.frmMonedas_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonedas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtAbreviatura;
        private System.Windows.Forms.BindingSource bsListado;
        private System.Windows.Forms.TextBox txtFecMod;
        private System.Windows.Forms.TextBox txtFecReg;
        private System.Windows.Forms.TextBox txtIdMoneda;
        private System.Windows.Forms.TextBox txtUsuMod;
        private System.Windows.Forms.TextBox txtUsuReg;
        private System.Windows.Forms.DataGridView dgvMonedas;
        private System.Windows.Forms.BindingSource bsDatos;
        private System.Windows.Forms.TextBox txtIso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISO;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Label label6;
    }
}