namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoLibroConcar
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
            this.dgvConcar = new System.Windows.Forms.DataGridView();
            this.csubdiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComprobanteDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFileDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLibroConcar = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLibroConcar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvConcar);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(5, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 331);
            this.panel1.TabIndex = 257;
            // 
            // dgvConcar
            // 
            this.dgvConcar.AllowUserToAddRows = false;
            this.dgvConcar.AllowUserToDeleteRows = false;
            this.dgvConcar.AutoGenerateColumns = false;
            this.dgvConcar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConcar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.csubdiaDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.idComprobante,
            this.IdComprobanteDes,
            this.numFile,
            this.numFileDes,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvConcar.DataSource = this.bsLibroConcar;
            this.dgvConcar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConcar.EnableHeadersVisualStyles = false;
            this.dgvConcar.Location = new System.Drawing.Point(0, 23);
            this.dgvConcar.Name = "dgvConcar";
            this.dgvConcar.ReadOnly = true;
            this.dgvConcar.Size = new System.Drawing.Size(727, 306);
            this.dgvConcar.TabIndex = 248;
            this.dgvConcar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConcar_CellDoubleClick);
            // 
            // csubdiaDataGridViewTextBoxColumn
            // 
            this.csubdiaDataGridViewTextBoxColumn.DataPropertyName = "csubdia";
            this.csubdiaDataGridViewTextBoxColumn.HeaderText = "Diario";
            this.csubdiaDataGridViewTextBoxColumn.Name = "csubdiaDataGridViewTextBoxColumn";
            this.csubdiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.csubdiaDataGridViewTextBoxColumn.Width = 45;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 150;
            // 
            // idComprobante
            // 
            this.idComprobante.DataPropertyName = "idComprobante";
            this.idComprobante.HeaderText = "Libro";
            this.idComprobante.Name = "idComprobante";
            this.idComprobante.ReadOnly = true;
            // 
            // IdComprobanteDes
            // 
            this.IdComprobanteDes.DataPropertyName = "IdComprobanteDes";
            this.IdComprobanteDes.HeaderText = "LibroDes";
            this.IdComprobanteDes.Name = "IdComprobanteDes";
            this.IdComprobanteDes.ReadOnly = true;
            this.IdComprobanteDes.Width = 140;
            // 
            // numFile
            // 
            this.numFile.DataPropertyName = "numFile";
            this.numFile.HeaderText = "File";
            this.numFile.Name = "numFile";
            this.numFile.ReadOnly = true;
            // 
            // numFileDes
            // 
            this.numFileDes.DataPropertyName = "numFileDes";
            this.numFileDes.HeaderText = "FileDes";
            this.numFileDes.Name = "numFileDes";
            this.numFileDes.ReadOnly = true;
            this.numFileDes.Width = 140;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // bsLibroConcar
            // 
            this.bsLibroConcar.DataSource = typeof(Entidades.Contabilidad.LibroConcarE);
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
            this.lblRegistros.Size = new System.Drawing.Size(727, 23);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Libro Concar - Registro";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoLibroConcar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 333);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoLibroConcar";
            this.Text = "Listado Libro Concar";
            this.Activated += new System.EventHandler(this.frmListadoLibroConcar_Activated);
            this.Load += new System.EventHandler(this.frmListadoLibroConcar_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLibroConcar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvConcar;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsLibroConcar;
        private System.Windows.Forms.DataGridViewTextBoxColumn csubdiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComprobanteDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFileDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}