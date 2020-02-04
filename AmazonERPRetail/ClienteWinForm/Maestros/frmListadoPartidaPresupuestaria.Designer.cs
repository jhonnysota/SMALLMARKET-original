namespace ClienteWinForm.Maestros
{
    partial class frmListadoPartidaPresupuestaria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rbGa = new System.Windows.Forms.RadioButton();
            this.rbRe = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dvgPartidas = new System.Windows.Forms.DataGridView();
            this.codPartidaPresuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desPartidaPresuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPartidas = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.rbGa);
            this.panel2.Controls.Add(this.rbRe);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 74);
            this.panel2.TabIndex = 271;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(158, 44);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(345, 21);
            this.txtDescripcion.TabIndex = 271;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "Ingrese la descripción";
            // 
            // button2
            // 
            this.button2.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button2.Location = new System.Drawing.Point(1217, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 59);
            this.button2.TabIndex = 154;
            this.button2.Text = "BUSCAR";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // rbGa
            // 
            this.rbGa.AutoSize = true;
            this.rbGa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGa.Location = new System.Drawing.Point(17, 48);
            this.rbGa.Name = "rbGa";
            this.rbGa.Size = new System.Drawing.Size(107, 17);
            this.rbGa.TabIndex = 75;
            this.rbGa.Text = "Gastos - Partidas";
            this.rbGa.UseVisualStyleBackColor = true;
            // 
            // rbRe
            // 
            this.rbRe.AutoSize = true;
            this.rbRe.Checked = true;
            this.rbRe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRe.Location = new System.Drawing.Point(17, 25);
            this.rbRe.Name = "rbRe";
            this.rbRe.Size = new System.Drawing.Size(113, 17);
            this.rbRe.TabIndex = 74;
            this.rbRe.TabStop = true;
            this.rbRe.Text = "Recursos - Rubros";
            this.rbRe.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dvgPartidas);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(4, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 371);
            this.panel1.TabIndex = 73;
            // 
            // dvgPartidas
            // 
            this.dvgPartidas.AllowUserToAddRows = false;
            this.dvgPartidas.AllowUserToDeleteRows = false;
            this.dvgPartidas.AutoGenerateColumns = false;
            this.dvgPartidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codPartidaPresuDataGridViewTextBoxColumn,
            this.desPartidaPresuDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dvgPartidas.DataSource = this.bsPartidas;
            this.dvgPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgPartidas.EnableHeadersVisualStyles = false;
            this.dvgPartidas.Location = new System.Drawing.Point(0, 18);
            this.dvgPartidas.Margin = new System.Windows.Forms.Padding(2);
            this.dvgPartidas.Name = "dvgPartidas";
            this.dvgPartidas.ReadOnly = true;
            this.dvgPartidas.RowTemplate.Height = 24;
            this.dvgPartidas.Size = new System.Drawing.Size(717, 351);
            this.dvgPartidas.TabIndex = 80;
            this.dvgPartidas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgPartidas_CellDoubleClick);
            // 
            // codPartidaPresuDataGridViewTextBoxColumn
            // 
            this.codPartidaPresuDataGridViewTextBoxColumn.DataPropertyName = "codPartidaPresu";
            this.codPartidaPresuDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codPartidaPresuDataGridViewTextBoxColumn.Name = "codPartidaPresuDataGridViewTextBoxColumn";
            this.codPartidaPresuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desPartidaPresuDataGridViewTextBoxColumn
            // 
            this.desPartidaPresuDataGridViewTextBoxColumn.DataPropertyName = "desPartidaPresu";
            this.desPartidaPresuDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desPartidaPresuDataGridViewTextBoxColumn.Name = "desPartidaPresuDataGridViewTextBoxColumn";
            this.desPartidaPresuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "fechaRegistro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "fechaModificacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsPartidas
            // 
            this.bsPartidas.DataSource = typeof(Entidades.Maestros.PartidaPresupuestariaE);
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(522, 18);
            this.label8.TabIndex = 431;
            this.label8.Text = "Parámetros de Búsqueda";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(717, 18);
            this.lblTitulo.TabIndex = 431;
            this.lblTitulo.Text = "Parámetros de Búsqueda";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoPartidaPresupuestaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 457);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoPartidaPresupuestaria";
            this.Text = "Listado de Partida Presupuestaria";
            this.Load += new System.EventHandler(this.frmListadoPartidaPresupuestaria_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dvgPartidas;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbGa;
        private System.Windows.Forms.RadioButton rbRe;
        private System.Windows.Forms.Panel panel2;
        protected internal System.Windows.Forms.Button button2;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.BindingSource bsPartidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPartidaPresuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desPartidaPresuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTitulo;
    }
}