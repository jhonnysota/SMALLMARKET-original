namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoPeriodos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPeriodos = new System.Windows.Forms.DataGridView();
            this.anioPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecFinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPeriodo = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeriodo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvPeriodos);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 326);
            this.panel1.TabIndex = 255;
            // 
            // dgvPeriodos
            // 
            this.dgvPeriodos.AllowUserToAddRows = false;
            this.dgvPeriodos.AllowUserToDeleteRows = false;
            this.dgvPeriodos.AutoGenerateColumns = false;
            this.dgvPeriodos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.anioPeriodoDataGridViewTextBoxColumn,
            this.mesPeriodoDataGridViewTextBoxColumn,
            this.desPeriodoDataGridViewTextBoxColumn,
            this.fecInicioDataGridViewTextBoxColumn,
            this.fecFinalDataGridViewTextBoxColumn,
            this.TCCompra,
            this.TCVenta,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvPeriodos.DataSource = this.bsPeriodo;
            this.dgvPeriodos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeriodos.EnableHeadersVisualStyles = false;
            this.dgvPeriodos.Location = new System.Drawing.Point(0, 18);
            this.dgvPeriodos.Name = "dgvPeriodos";
            this.dgvPeriodos.ReadOnly = true;
            this.dgvPeriodos.Size = new System.Drawing.Size(659, 306);
            this.dgvPeriodos.TabIndex = 248;
            this.dgvPeriodos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodos_CellDoubleClick);
            // 
            // anioPeriodoDataGridViewTextBoxColumn
            // 
            this.anioPeriodoDataGridViewTextBoxColumn.DataPropertyName = "AnioPeriodo";
            this.anioPeriodoDataGridViewTextBoxColumn.HeaderText = "Año";
            this.anioPeriodoDataGridViewTextBoxColumn.Name = "anioPeriodoDataGridViewTextBoxColumn";
            this.anioPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.anioPeriodoDataGridViewTextBoxColumn.Visible = false;
            // 
            // mesPeriodoDataGridViewTextBoxColumn
            // 
            this.mesPeriodoDataGridViewTextBoxColumn.DataPropertyName = "MesPeriodo";
            this.mesPeriodoDataGridViewTextBoxColumn.HeaderText = "Mes";
            this.mesPeriodoDataGridViewTextBoxColumn.Name = "mesPeriodoDataGridViewTextBoxColumn";
            this.mesPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desPeriodoDataGridViewTextBoxColumn
            // 
            this.desPeriodoDataGridViewTextBoxColumn.DataPropertyName = "desPeriodo";
            this.desPeriodoDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desPeriodoDataGridViewTextBoxColumn.Name = "desPeriodoDataGridViewTextBoxColumn";
            this.desPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fecInicioDataGridViewTextBoxColumn
            // 
            this.fecInicioDataGridViewTextBoxColumn.DataPropertyName = "fecInicio";
            this.fecInicioDataGridViewTextBoxColumn.HeaderText = "F. Inicio";
            this.fecInicioDataGridViewTextBoxColumn.Name = "fecInicioDataGridViewTextBoxColumn";
            this.fecInicioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fecFinalDataGridViewTextBoxColumn
            // 
            this.fecFinalDataGridViewTextBoxColumn.DataPropertyName = "fecFinal";
            this.fecFinalDataGridViewTextBoxColumn.HeaderText = "F. Final";
            this.fecFinalDataGridViewTextBoxColumn.Name = "fecFinalDataGridViewTextBoxColumn";
            this.fecFinalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TCCompra
            // 
            this.TCCompra.DataPropertyName = "TCCompra";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N3";
            this.TCCompra.DefaultCellStyle = dataGridViewCellStyle7;
            this.TCCompra.HeaderText = "TC Compra";
            this.TCCompra.Name = "TCCompra";
            this.TCCompra.ReadOnly = true;
            this.TCCompra.Width = 80;
            // 
            // TCVenta
            // 
            this.TCVenta.DataPropertyName = "TCVenta";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N3";
            this.TCVenta.DefaultCellStyle = dataGridViewCellStyle8;
            this.TCVenta.HeaderText = "TC Venta";
            this.TCVenta.Name = "TCVenta";
            this.TCVenta.ReadOnly = true;
            this.TCVenta.Width = 80;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Registro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Registro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.AliceBlue;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Modificación";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.AliceBlue;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Modificación";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsPeriodo
            // 
            this.bsPeriodo.DataSource = typeof(Entidades.Contabilidad.PeriodosE);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(659, 18);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Periodos - Registro";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 256;
            this.label1.Text = "Año";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(50, 5);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(50, 20);
            this.txtAño.TabIndex = 257;
            // 
            // frmListadoPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 360);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.Name = "frmListadoPeriodos";
            this.Text = "Listado de Periodos";
            this.Load += new System.EventHandler(this.frmListadoPeriodos_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeriodo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPeriodos;
        private System.Windows.Forms.BindingSource bsPeriodo;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecFinalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}