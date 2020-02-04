namespace ClienteWinForm.Generales
{
    partial class frmListadoImpuestos
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
            this.bsImpuestos = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvControl = new System.Windows.Forms.DataGridView();
            this.idImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desAbreviaturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsImpuestos)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControl)).BeginInit();
            this.SuspendLayout();
            // 
            // bsImpuestos
            // 
            this.bsImpuestos.DataSource = typeof(Entidades.Generales.ImpuestosE);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvControl);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(643, 284);
            this.panel5.TabIndex = 262;
            // 
            // dgvControl
            // 
            this.dgvControl.AllowUserToAddRows = false;
            this.dgvControl.AllowUserToDeleteRows = false;
            this.dgvControl.AutoGenerateColumns = false;
            this.dgvControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idImpuestoDataGridViewTextBoxColumn,
            this.desImpuestoDataGridViewTextBoxColumn,
            this.desAbreviaturaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvControl.DataSource = this.bsImpuestos;
            this.dgvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvControl.EnableHeadersVisualStyles = false;
            this.dgvControl.Location = new System.Drawing.Point(0, 18);
            this.dgvControl.Name = "dgvControl";
            this.dgvControl.ReadOnly = true;
            this.dgvControl.Size = new System.Drawing.Size(641, 264);
            this.dgvControl.TabIndex = 250;
            this.dgvControl.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvControl_CellDoubleClick);
            this.dgvControl.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvControl_CellFormatting);
            // 
            // idImpuestoDataGridViewTextBoxColumn
            // 
            this.idImpuestoDataGridViewTextBoxColumn.DataPropertyName = "idImpuesto";
            this.idImpuestoDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idImpuestoDataGridViewTextBoxColumn.Name = "idImpuestoDataGridViewTextBoxColumn";
            this.idImpuestoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desImpuestoDataGridViewTextBoxColumn
            // 
            this.desImpuestoDataGridViewTextBoxColumn.DataPropertyName = "desImpuesto";
            this.desImpuestoDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desImpuestoDataGridViewTextBoxColumn.Name = "desImpuestoDataGridViewTextBoxColumn";
            this.desImpuestoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desAbreviaturaDataGridViewTextBoxColumn
            // 
            this.desAbreviaturaDataGridViewTextBoxColumn.DataPropertyName = "desAbreviatura";
            this.desAbreviaturaDataGridViewTextBoxColumn.HeaderText = "Desc. Corta";
            this.desAbreviaturaDataGridViewTextBoxColumn.Name = "desAbreviaturaDataGridViewTextBoxColumn";
            this.desAbreviaturaDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
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
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(641, 18);
            this.lblRegistros.TabIndex = 1574;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 292);
            this.Controls.Add(this.panel5);
            this.Name = "frmListadoImpuestos";
            this.Text = "Listado De Impuestos";
            this.Activated += new System.EventHandler(this.frmListadoImpuestos_Activated);
            this.Load += new System.EventHandler(this.frmListadoImpuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsImpuestos)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvControl;
        private System.Windows.Forms.BindingSource bsImpuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idImpuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desImpuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desAbreviaturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistros;
    }
}