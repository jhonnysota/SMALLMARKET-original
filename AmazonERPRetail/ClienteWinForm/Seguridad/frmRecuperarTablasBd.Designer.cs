namespace ClienteWinForm.Seguridad
{
    partial class frmRecuperarTablasBd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.txtNombreBD = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTablas = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TablaReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSistema = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsTablas = new System.Windows.Forms.BindingSource(this.components);
            this.txtBuscar = new ControlesWinForm.SuperTextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btRecuperarTablas = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTablas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.labelDegradado2);
            this.panel4.Controls.Add(this.txtNombreBD);
            this.panel4.Controls.Add(this.txtServidor);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(582, 85);
            this.panel4.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClienteWinForm.Properties.Resources.DB;
            this.pictureBox1.Location = new System.Drawing.Point(418, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 272;
            this.pictureBox1.TabStop = false;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(580, 20);
            this.labelDegradado2.TabIndex = 271;
            this.labelDegradado2.Text = "Conexión con la BD";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreBD
            // 
            this.txtNombreBD.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNombreBD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreBD.Enabled = false;
            this.txtNombreBD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreBD.Location = new System.Drawing.Point(129, 52);
            this.txtNombreBD.Name = "txtNombreBD";
            this.txtNombreBD.Size = new System.Drawing.Size(281, 21);
            this.txtNombreBD.TabIndex = 9;
            // 
            // txtServidor
            // 
            this.txtServidor.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtServidor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServidor.Enabled = false;
            this.txtServidor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidor.Location = new System.Drawing.Point(129, 29);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(281, 21);
            this.txtServidor.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(56, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nombre BD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(56, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Servidor";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvTablas);
            this.panel3.Controls.Add(this.txtBuscar);
            this.panel3.Controls.Add(this.labelDegradado1);
            this.panel3.Controls.Add(this.btRecuperarTablas);
            this.panel3.Location = new System.Drawing.Point(4, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 313);
            this.panel3.TabIndex = 4;
            // 
            // dgvTablas
            // 
            this.dgvTablas.AllowUserToAddRows = false;
            this.dgvTablas.AllowUserToDeleteRows = false;
            this.dgvTablas.AutoGenerateColumns = false;
            this.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.TablaReal,
            this.Descripcion,
            this.Orden,
            this.idSistema});
            this.dgvTablas.DataSource = this.bsTablas;
            this.dgvTablas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTablas.EnableHeadersVisualStyles = false;
            this.dgvTablas.Location = new System.Drawing.Point(0, 66);
            this.dgvTablas.Name = "dgvTablas";
            this.dgvTablas.Size = new System.Drawing.Size(580, 245);
            this.dgvTablas.TabIndex = 274;
            this.dgvTablas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablas_CellEnter);
            this.dgvTablas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTablas_DataError);
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.HeaderText = "X";
            this.Check.Name = "Check";
            this.Check.ToolTipText = "Escoger Tabla";
            // 
            // TablaReal
            // 
            this.TablaReal.DataPropertyName = "TablaReal";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            this.TablaReal.DefaultCellStyle = dataGridViewCellStyle1;
            this.TablaReal.HeaderText = "Nombre Tabla";
            this.TablaReal.Name = "TablaReal";
            this.TablaReal.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            // 
            // Orden
            // 
            this.Orden.DataPropertyName = "Orden";
            dataGridViewCellStyle2.NullValue = " ";
            this.Orden.DefaultCellStyle = dataGridViewCellStyle2;
            this.Orden.HeaderText = "Orden";
            this.Orden.Name = "Orden";
            // 
            // idSistema
            // 
            this.idSistema.DataPropertyName = "idSistema";
            this.idSistema.HeaderText = "Sistema";
            this.idSistema.Name = "idSistema";
            // 
            // bsTablas
            // 
            this.bsTablas.DataSource = typeof(Entidades.Seguridad.ClonacionTablasE);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtBuscar.Location = new System.Drawing.Point(144, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(364, 20);
            this.txtBuscar.TabIndex = 273;
            this.txtBuscar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtBuscar.TextoVacio = "Buscar Nombre Tabla";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(580, 20);
            this.labelDegradado1.TabIndex = 272;
            this.labelDegradado1.Text = "Tablas de BD";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btRecuperarTablas
            // 
            this.btRecuperarTablas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btRecuperarTablas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btRecuperarTablas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btRecuperarTablas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRecuperarTablas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRecuperarTablas.ForeColor = System.Drawing.Color.Black;
            this.btRecuperarTablas.Image = global::ClienteWinForm.Properties.Resources.DBFind;
            this.btRecuperarTablas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRecuperarTablas.Location = new System.Drawing.Point(9, 30);
            this.btRecuperarTablas.Name = "btRecuperarTablas";
            this.btRecuperarTablas.Size = new System.Drawing.Size(129, 27);
            this.btRecuperarTablas.TabIndex = 2;
            this.btRecuperarTablas.Text = "Buscar Tablas";
            this.btRecuperarTablas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRecuperarTablas.UseVisualStyleBackColor = true;
            this.btRecuperarTablas.Click += new System.EventHandler(this.btRecuperarTablas_Click);
            // 
            // frmRecuperarTablasBd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 407);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.Name = "frmRecuperarTablasBd";
            this.Text = "Recuperar Tablas de BD";
            this.Load += new System.EventHandler(this.frmRecuperarTablasBd_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTablas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtNombreBD;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btRecuperarTablas;
        private MyLabelG.LabelDegradado labelDegradado2;
        private ControlesWinForm.SuperTextBox txtBuscar;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.DataGridView dgvTablas;
        private System.Windows.Forms.BindingSource bsTablas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.DataGridViewComboBoxColumn idSistema;
    }
}