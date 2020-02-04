namespace ClienteWinForm.Contabilidad
{
    partial class frmPeriodosControl
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
            this.bsPeriodo = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPeriodo = new System.Windows.Forms.DataGridView();
            this.desPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCierreDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indAperturaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indReaperturaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indAjusteDifCambioDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indAaFinMesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indEfectivoAsientosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indAjustePorDocFinMesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indEfectivoAjusteFinMesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeriodo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodo)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPeriodo
            // 
            this.bsPeriodo.DataSource = typeof(Entidades.Contabilidad.PeriodosE);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1048, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 259;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvPeriodo);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 354);
            this.panel1.TabIndex = 258;
            // 
            // dgvPeriodo
            // 
            this.dgvPeriodo.AllowUserToAddRows = false;
            this.dgvPeriodo.AllowUserToDeleteRows = false;
            this.dgvPeriodo.AutoGenerateColumns = false;
            this.dgvPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desPeriodo,
            this.indCierreDataGridViewCheckBoxColumn,
            this.indAperturaDataGridViewCheckBoxColumn,
            this.indReaperturaDataGridViewCheckBoxColumn,
            this.indAjusteDifCambioDataGridViewCheckBoxColumn,
            this.indAaFinMesDataGridViewCheckBoxColumn,
            this.indEfectivoAsientosDataGridViewCheckBoxColumn,
            this.indAjustePorDocFinMesDataGridViewCheckBoxColumn,
            this.indEfectivoAjusteFinMesDataGridViewCheckBoxColumn,
            this.UsuarioRegistro,
            this.FechaRegistro,
            this.UsuarioModificacion,
            this.FechaModificacion});
            this.dgvPeriodo.DataSource = this.bsPeriodo;
            this.dgvPeriodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeriodo.EnableHeadersVisualStyles = false;
            this.dgvPeriodo.Location = new System.Drawing.Point(0, 23);
            this.dgvPeriodo.Name = "dgvPeriodo";
            this.dgvPeriodo.Size = new System.Drawing.Size(998, 329);
            this.dgvPeriodo.TabIndex = 248;
            this.dgvPeriodo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodo_CellDoubleClick);
            this.dgvPeriodo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPeriodo_CellFormatting);
            this.dgvPeriodo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodo_CellValueChanged);
            // 
            // desPeriodo
            // 
            this.desPeriodo.DataPropertyName = "desPeriodo";
            this.desPeriodo.HeaderText = "Periodo";
            this.desPeriodo.Name = "desPeriodo";
            // 
            // indCierreDataGridViewCheckBoxColumn
            // 
            this.indCierreDataGridViewCheckBoxColumn.DataPropertyName = "indCierre";
            this.indCierreDataGridViewCheckBoxColumn.HeaderText = "Cierre";
            this.indCierreDataGridViewCheckBoxColumn.Name = "indCierreDataGridViewCheckBoxColumn";
            this.indCierreDataGridViewCheckBoxColumn.Width = 60;
            // 
            // indAperturaDataGridViewCheckBoxColumn
            // 
            this.indAperturaDataGridViewCheckBoxColumn.DataPropertyName = "indApertura";
            this.indAperturaDataGridViewCheckBoxColumn.HeaderText = "Apertura";
            this.indAperturaDataGridViewCheckBoxColumn.Name = "indAperturaDataGridViewCheckBoxColumn";
            this.indAperturaDataGridViewCheckBoxColumn.Width = 60;
            // 
            // indReaperturaDataGridViewCheckBoxColumn
            // 
            this.indReaperturaDataGridViewCheckBoxColumn.DataPropertyName = "indReapertura";
            this.indReaperturaDataGridViewCheckBoxColumn.HeaderText = "Reapertura";
            this.indReaperturaDataGridViewCheckBoxColumn.Name = "indReaperturaDataGridViewCheckBoxColumn";
            this.indReaperturaDataGridViewCheckBoxColumn.Width = 60;
            // 
            // indAjusteDifCambioDataGridViewCheckBoxColumn
            // 
            this.indAjusteDifCambioDataGridViewCheckBoxColumn.DataPropertyName = "indAjusteDifCambio";
            this.indAjusteDifCambioDataGridViewCheckBoxColumn.HeaderText = "Aj. Dif Cambio";
            this.indAjusteDifCambioDataGridViewCheckBoxColumn.Name = "indAjusteDifCambioDataGridViewCheckBoxColumn";
            this.indAjusteDifCambioDataGridViewCheckBoxColumn.Width = 60;
            // 
            // indAaFinMesDataGridViewCheckBoxColumn
            // 
            this.indAaFinMesDataGridViewCheckBoxColumn.DataPropertyName = "indAaFinMes";
            this.indAaFinMesDataGridViewCheckBoxColumn.HeaderText = "A Fin Mes";
            this.indAaFinMesDataGridViewCheckBoxColumn.Name = "indAaFinMesDataGridViewCheckBoxColumn";
            this.indAaFinMesDataGridViewCheckBoxColumn.Width = 60;
            // 
            // indEfectivoAsientosDataGridViewCheckBoxColumn
            // 
            this.indEfectivoAsientosDataGridViewCheckBoxColumn.DataPropertyName = "indEfectivoAsientos";
            this.indEfectivoAsientosDataGridViewCheckBoxColumn.HeaderText = "Efectivo Asientos";
            this.indEfectivoAsientosDataGridViewCheckBoxColumn.Name = "indEfectivoAsientosDataGridViewCheckBoxColumn";
            this.indEfectivoAsientosDataGridViewCheckBoxColumn.Width = 60;
            // 
            // indAjustePorDocFinMesDataGridViewCheckBoxColumn
            // 
            this.indAjustePorDocFinMesDataGridViewCheckBoxColumn.DataPropertyName = "indAjustePorDocFinMes";
            this.indAjustePorDocFinMesDataGridViewCheckBoxColumn.HeaderText = "Ajuste Fin Mes";
            this.indAjustePorDocFinMesDataGridViewCheckBoxColumn.Name = "indAjustePorDocFinMesDataGridViewCheckBoxColumn";
            this.indAjustePorDocFinMesDataGridViewCheckBoxColumn.Width = 60;
            // 
            // indEfectivoAjusteFinMesDataGridViewCheckBoxColumn
            // 
            this.indEfectivoAjusteFinMesDataGridViewCheckBoxColumn.DataPropertyName = "indEfectivoAjusteFinMes";
            this.indEfectivoAjusteFinMesDataGridViewCheckBoxColumn.HeaderText = "Efectivo Fin Mes";
            this.indEfectivoAjusteFinMesDataGridViewCheckBoxColumn.Name = "indEfectivoAjusteFinMesDataGridViewCheckBoxColumn";
            this.indEfectivoAjusteFinMesDataGridViewCheckBoxColumn.Width = 60;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            this.UsuarioRegistro.HeaderText = "UsuarioRegistro";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            this.FechaRegistro.HeaderText = "FechaRegistro";
            this.FechaRegistro.Name = "FechaRegistro";
            // 
            // UsuarioModificacion
            // 
            this.UsuarioModificacion.DataPropertyName = "UsuarioModificacion";
            this.UsuarioModificacion.HeaderText = "UsuarioModificacion";
            this.UsuarioModificacion.Name = "UsuarioModificacion";
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            this.FechaModificacion.HeaderText = "FechaModificacion";
            this.FechaModificacion.Name = "FechaModificacion";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(998, 23);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Periodos - Registro";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPeriodosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 360);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmPeriodosControl";
            this.Text = "Control De Cierres";
            this.Load += new System.EventHandler(this.frmPeriodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPeriodo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPeriodo;
        private System.Windows.Forms.BindingSource bsPeriodo;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn desPeriodo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCierreDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indAperturaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indReaperturaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indAjusteDifCambioDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indAaFinMesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEfectivoAsientosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indAjustePorDocFinMesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEfectivoAjusteFinMesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
    }
}