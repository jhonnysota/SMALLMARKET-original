namespace ClienteWinForm.Contabilidad
{
    partial class FrmListadoEmpresaConcar
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
            this.dgvEmpConcar = new System.Windows.Forms.DataGridView();
            this.bsEmpConcar = new System.Windows.Forms.BindingSource(this.components);
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.codEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpConcar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpConcar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpConcar
            // 
            this.dgvEmpConcar.AllowUserToAddRows = false;
            this.dgvEmpConcar.AllowUserToDeleteRows = false;
            this.dgvEmpConcar.AutoGenerateColumns = false;
            this.dgvEmpConcar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpConcar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpConcar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codEmpresaDataGridViewTextBoxColumn,
            this.nomEmpresaDataGridViewTextBoxColumn,
            this.idEmpresaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvEmpConcar.DataSource = this.bsEmpConcar;
            this.dgvEmpConcar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmpConcar.EnableHeadersVisualStyles = false;
            this.dgvEmpConcar.Location = new System.Drawing.Point(0, 18);
            this.dgvEmpConcar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEmpConcar.Name = "dgvEmpConcar";
            this.dgvEmpConcar.ReadOnly = true;
            this.dgvEmpConcar.RowTemplate.Height = 24;
            this.dgvEmpConcar.Size = new System.Drawing.Size(740, 423);
            this.dgvEmpConcar.TabIndex = 271;
            this.dgvEmpConcar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpConcar_CellDoubleClick);
            // 
            // bsEmpConcar
            // 
            this.bsEmpConcar.DataSource = typeof(Entidades.Contabilidad.EmpresaConcarE);
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
            this.lblTitulo.Size = new System.Drawing.Size(740, 18);
            this.lblTitulo.TabIndex = 272;
            this.lblTitulo.Text = "Registros ";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // codEmpresaDataGridViewTextBoxColumn
            // 
            this.codEmpresaDataGridViewTextBoxColumn.DataPropertyName = "CodEmpresa";
            this.codEmpresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.codEmpresaDataGridViewTextBoxColumn.Name = "codEmpresaDataGridViewTextBoxColumn";
            this.codEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codEmpresaDataGridViewTextBoxColumn.Width = 60;
            // 
            // nomEmpresaDataGridViewTextBoxColumn
            // 
            this.nomEmpresaDataGridViewTextBoxColumn.DataPropertyName = "NomEmpresa";
            this.nomEmpresaDataGridViewTextBoxColumn.HeaderText = "NomEmpresa";
            this.nomEmpresaDataGridViewTextBoxColumn.Name = "nomEmpresaDataGridViewTextBoxColumn";
            this.nomEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomEmpresaDataGridViewTextBoxColumn.Width = 150;
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
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
            // FrmListadoEmpresaConcar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 441);
            this.Controls.Add(this.dgvEmpConcar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmListadoEmpresaConcar";
            this.Text = "Listado Empresa Concar";
            this.Activated += new System.EventHandler(this.FrmListadoEmpresaConcar_Activated);
            this.Load += new System.EventHandler(this.FrmListadoEmpresaConcar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpConcar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpConcar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpConcar;
        private System.Windows.Forms.BindingSource bsEmpConcar;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}