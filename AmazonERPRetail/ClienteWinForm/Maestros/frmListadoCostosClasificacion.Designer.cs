namespace ClienteWinForm.Maestros
{
    partial class frmListadoCostosClasificacion
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
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.dgvCostosClasificacion = new System.Windows.Forms.DataGridView();
            this.bsCostosClasificacion = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.CodClasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodCategoriaSup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indUltimoNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostosClasificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCostosClasificacion)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(704, 21);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCostosClasificacion
            // 
            this.dgvCostosClasificacion.AllowUserToAddRows = false;
            this.dgvCostosClasificacion.AllowUserToDeleteRows = false;
            this.dgvCostosClasificacion.AutoGenerateColumns = false;
            this.dgvCostosClasificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCostosClasificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostosClasificacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodClasificacion,
            this.nombreClasificacion,
            this.numNivel,
            this.CodCategoriaSup,
            this.indUltimoNivel,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvCostosClasificacion.DataSource = this.bsCostosClasificacion;
            this.dgvCostosClasificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCostosClasificacion.EnableHeadersVisualStyles = false;
            this.dgvCostosClasificacion.Location = new System.Drawing.Point(0, 21);
            this.dgvCostosClasificacion.Name = "dgvCostosClasificacion";
            this.dgvCostosClasificacion.ReadOnly = true;
            this.dgvCostosClasificacion.Size = new System.Drawing.Size(704, 409);
            this.dgvCostosClasificacion.TabIndex = 248;
            this.dgvCostosClasificacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCostosClasificacion_CellDoubleClick);
            // 
            // bsCostosClasificacion
            // 
            this.bsCostosClasificacion.DataSource = typeof(Entidades.Maestros.CostosClasificacionE);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvCostosClasificacion);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(7, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 432);
            this.panel1.TabIndex = 258;
            // 
            // CodClasificacion
            // 
            this.CodClasificacion.DataPropertyName = "CodClasificacion";
            this.CodClasificacion.HeaderText = "Código";
            this.CodClasificacion.Name = "CodClasificacion";
            this.CodClasificacion.ReadOnly = true;
            // 
            // nombreClasificacion
            // 
            this.nombreClasificacion.DataPropertyName = "nombreClasificacion";
            this.nombreClasificacion.HeaderText = "Nombre";
            this.nombreClasificacion.Name = "nombreClasificacion";
            this.nombreClasificacion.ReadOnly = true;
            this.nombreClasificacion.Width = 150;
            // 
            // numNivel
            // 
            this.numNivel.DataPropertyName = "numNivel";
            this.numNivel.HeaderText = "numNivel";
            this.numNivel.Name = "numNivel";
            this.numNivel.ReadOnly = true;
            // 
            // CodCategoriaSup
            // 
            this.CodCategoriaSup.DataPropertyName = "CodCategoriaSup";
            this.CodCategoriaSup.HeaderText = "CodCategoriaSup";
            this.CodCategoriaSup.Name = "CodCategoriaSup";
            this.CodCategoriaSup.ReadOnly = true;
            // 
            // indUltimoNivel
            // 
            this.indUltimoNivel.DataPropertyName = "indUltimoNivel";
            this.indUltimoNivel.HeaderText = "indUltimoNivel";
            this.indUltimoNivel.Name = "indUltimoNivel";
            this.indUltimoNivel.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmListadoCostosClasificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 442);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoCostosClasificacion";
            this.Text = "Listado Costos Clasificacion";
            this.Activated += new System.EventHandler(this.frmListadoCostosClasificacion_Activated);
            this.Load += new System.EventHandler(this.frmListadoCostosClasificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostosClasificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCostosClasificacion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.DataGridView dgvCostosClasificacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bsCostosClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCategoriaSup;
        private System.Windows.Forms.DataGridViewTextBoxColumn indUltimoNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}