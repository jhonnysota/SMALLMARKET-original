namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoEEFFRatios
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListadoEEFF = new System.Windows.Forms.DataGridView();
            this.bsEEFFRatios = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.idItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desGlosaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoTablaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagActivoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFRatios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListadoEEFF);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(2, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(881, 405);
            this.panel5.TabIndex = 260;
            // 
            // dgvListadoEEFF
            // 
            this.dgvListadoEEFF.AllowUserToAddRows = false;
            this.dgvListadoEEFF.AllowUserToDeleteRows = false;
            this.dgvListadoEEFF.AutoGenerateColumns = false;
            this.dgvListadoEEFF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEEFF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItemDataGridViewTextBoxColumn,
            this.secItemDataGridViewTextBoxColumn,
            this.desItemDataGridViewTextBoxColumn,
            this.desGlosaDataGridViewTextBoxColumn,
            this.tipoTablaDataGridViewTextBoxColumn,
            this.formulaDataGridViewTextBoxColumn,
            this.flagActivoDataGridViewCheckBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvListadoEEFF.DataSource = this.bsEEFFRatios;
            this.dgvListadoEEFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoEEFF.EnableHeadersVisualStyles = false;
            this.dgvListadoEEFF.Location = new System.Drawing.Point(0, 23);
            this.dgvListadoEEFF.Name = "dgvListadoEEFF";
            this.dgvListadoEEFF.ReadOnly = true;
            this.dgvListadoEEFF.Size = new System.Drawing.Size(879, 380);
            this.dgvListadoEEFF.TabIndex = 248;
            this.dgvListadoEEFF.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoEEFF_CellDoubleClick);
            this.dgvListadoEEFF.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoEEFF_CellFormatting);
            // 
            // bsEEFFRatios
            // 
            this.bsEEFFRatios.DataSource = typeof(Entidades.Contabilidad.EEFFRatiosE);
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
            this.lblRegistros.Size = new System.Drawing.Size(879, 23);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Estados Financieros - Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // idItemDataGridViewTextBoxColumn
            // 
            this.idItemDataGridViewTextBoxColumn.DataPropertyName = "idItem";
            this.idItemDataGridViewTextBoxColumn.HeaderText = "idItem";
            this.idItemDataGridViewTextBoxColumn.Name = "idItemDataGridViewTextBoxColumn";
            this.idItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.idItemDataGridViewTextBoxColumn.Width = 50;
            // 
            // secItemDataGridViewTextBoxColumn
            // 
            this.secItemDataGridViewTextBoxColumn.DataPropertyName = "secItem";
            this.secItemDataGridViewTextBoxColumn.HeaderText = "secItem";
            this.secItemDataGridViewTextBoxColumn.Name = "secItemDataGridViewTextBoxColumn";
            this.secItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.secItemDataGridViewTextBoxColumn.Width = 60;
            // 
            // desItemDataGridViewTextBoxColumn
            // 
            this.desItemDataGridViewTextBoxColumn.DataPropertyName = "desItem";
            this.desItemDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.desItemDataGridViewTextBoxColumn.Name = "desItemDataGridViewTextBoxColumn";
            this.desItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.desItemDataGridViewTextBoxColumn.Width = 200;
            // 
            // desGlosaDataGridViewTextBoxColumn
            // 
            this.desGlosaDataGridViewTextBoxColumn.DataPropertyName = "desGlosa";
            this.desGlosaDataGridViewTextBoxColumn.HeaderText = "Glosa";
            this.desGlosaDataGridViewTextBoxColumn.Name = "desGlosaDataGridViewTextBoxColumn";
            this.desGlosaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoTablaDataGridViewTextBoxColumn
            // 
            this.tipoTablaDataGridViewTextBoxColumn.DataPropertyName = "TipoTabla";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipoTablaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tipoTablaDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoTablaDataGridViewTextBoxColumn.Name = "tipoTablaDataGridViewTextBoxColumn";
            this.tipoTablaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoTablaDataGridViewTextBoxColumn.Width = 40;
            // 
            // formulaDataGridViewTextBoxColumn
            // 
            this.formulaDataGridViewTextBoxColumn.DataPropertyName = "Formula";
            this.formulaDataGridViewTextBoxColumn.HeaderText = "Formula";
            this.formulaDataGridViewTextBoxColumn.Name = "formulaDataGridViewTextBoxColumn";
            this.formulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.formulaDataGridViewTextBoxColumn.Width = 250;
            // 
            // flagActivoDataGridViewCheckBoxColumn
            // 
            this.flagActivoDataGridViewCheckBoxColumn.DataPropertyName = "flagActivo";
            this.flagActivoDataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.flagActivoDataGridViewCheckBoxColumn.Name = "flagActivoDataGridViewCheckBoxColumn";
            this.flagActivoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.flagActivoDataGridViewCheckBoxColumn.Width = 50;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 80;
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
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 80;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmListadoEEFFRatios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 407);
            this.Controls.Add(this.panel5);
            this.Name = "frmListadoEEFFRatios";
            this.Text = "Listado EEFF Ratios";
            this.Load += new System.EventHandler(this.frmListadoEEFFRatios_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFRatios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoEEFF;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsEEFFRatios;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desGlosaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoTablaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flagActivoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}