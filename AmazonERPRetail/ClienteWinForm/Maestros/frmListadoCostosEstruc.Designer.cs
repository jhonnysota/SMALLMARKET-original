namespace ClienteWinForm.Maestros
{
    partial class frmListadoCostosEstruc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEstructura = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.bsCostosEstruc = new System.Windows.Forms.BindingSource(this.components);
            this.numNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numLongitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indUltimoNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstructura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCostosEstruc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvEstructura);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 371);
            this.panel1.TabIndex = 259;
            // 
            // dgvEstructura
            // 
            this.dgvEstructura.AllowUserToAddRows = false;
            this.dgvEstructura.AllowUserToDeleteRows = false;
            this.dgvEstructura.AutoGenerateColumns = false;
            this.dgvEstructura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEstructura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstructura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numNivelDataGridViewTextBoxColumn,
            this.desNivelDataGridViewTextBoxColumn,
            this.numLongitudDataGridViewTextBoxColumn,
            this.indUltimoNivelDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvEstructura.DataSource = this.bsCostosEstruc;
            this.dgvEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstructura.EnableHeadersVisualStyles = false;
            this.dgvEstructura.Location = new System.Drawing.Point(0, 18);
            this.dgvEstructura.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEstructura.Name = "dgvEstructura";
            this.dgvEstructura.ReadOnly = true;
            this.dgvEstructura.RowTemplate.Height = 24;
            this.dgvEstructura.Size = new System.Drawing.Size(616, 351);
            this.dgvEstructura.TabIndex = 80;
            this.dgvEstructura.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstructura_CellDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(616, 18);
            this.lblTitulo.TabIndex = 270;
            this.lblTitulo.Text = "Registros";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bsCostosEstruc
            // 
            this.bsCostosEstruc.DataSource = typeof(Entidades.Maestros.CostosEstrucE);
            // 
            // numNivelDataGridViewTextBoxColumn
            // 
            this.numNivelDataGridViewTextBoxColumn.DataPropertyName = "numNivel";
            this.numNivelDataGridViewTextBoxColumn.HeaderText = "Nivel";
            this.numNivelDataGridViewTextBoxColumn.Name = "numNivelDataGridViewTextBoxColumn";
            this.numNivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desNivelDataGridViewTextBoxColumn
            // 
            this.desNivelDataGridViewTextBoxColumn.DataPropertyName = "desNivel";
            this.desNivelDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.desNivelDataGridViewTextBoxColumn.Name = "desNivelDataGridViewTextBoxColumn";
            this.desNivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numLongitudDataGridViewTextBoxColumn
            // 
            this.numLongitudDataGridViewTextBoxColumn.DataPropertyName = "numLongitud";
            this.numLongitudDataGridViewTextBoxColumn.HeaderText = "Longitud";
            this.numLongitudDataGridViewTextBoxColumn.Name = "numLongitudDataGridViewTextBoxColumn";
            this.numLongitudDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indUltimoNivelDataGridViewTextBoxColumn
            // 
            this.indUltimoNivelDataGridViewTextBoxColumn.DataPropertyName = "indUltimoNivel";
            this.indUltimoNivelDataGridViewTextBoxColumn.HeaderText = "Ult.Niv.";
            this.indUltimoNivelDataGridViewTextBoxColumn.Name = "indUltimoNivelDataGridViewTextBoxColumn";
            this.indUltimoNivelDataGridViewTextBoxColumn.ReadOnly = true;
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
            // frmListadoCostosEstruc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 390);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoCostosEstruc";
            this.Text = "Listado Costos Estructura";
            this.Load += new System.EventHandler(this.frmListadoCostosEstruc_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstructura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCostosEstruc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEstructura;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.BindingSource bsCostosEstruc;
        private System.Windows.Forms.DataGridViewTextBoxColumn numNivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desNivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numLongitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indUltimoNivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}