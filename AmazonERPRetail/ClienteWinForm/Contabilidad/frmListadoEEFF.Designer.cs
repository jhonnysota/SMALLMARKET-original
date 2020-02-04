namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoEEFF
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
            this.bsEEFF = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListadoEEFF = new System.Windows.Forms.DataGridView();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEEFFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoSeccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desSeccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoReporteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indComparativoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indcCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFF)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFF)).BeginInit();
            this.SuspendLayout();
            // 
            // bsEEFF
            // 
            this.bsEEFF.DataSource = typeof(Entidades.Contabilidad.EEFFE);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListadoEEFF);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(5, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(881, 405);
            this.panel5.TabIndex = 259;
            // 
            // dgvListadoEEFF
            // 
            this.dgvListadoEEFF.AllowUserToAddRows = false;
            this.dgvListadoEEFF.AllowUserToDeleteRows = false;
            this.dgvListadoEEFF.AutoGenerateColumns = false;
            this.dgvListadoEEFF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEEFF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEmpresaDataGridViewTextBoxColumn,
            this.idEEFFDataGridViewTextBoxColumn,
            this.tipoSeccionDataGridViewTextBoxColumn,
            this.desSeccionDataGridViewTextBoxColumn,
            this.tipoReporteDataGridViewTextBoxColumn,
            this.indComparativoDataGridViewTextBoxColumn,
            this.indcCostosDataGridViewTextBoxColumn,
            this.UsuarioRegistro,
            this.FechaRegistro,
            this.UsuarioModificacion,
            this.FechaModificacion});
            this.dgvListadoEEFF.DataSource = this.bsEEFF;
            this.dgvListadoEEFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoEEFF.EnableHeadersVisualStyles = false;
            this.dgvListadoEEFF.Location = new System.Drawing.Point(0, 23);
            this.dgvListadoEEFF.Name = "dgvListadoEEFF";
            this.dgvListadoEEFF.ReadOnly = true;
            this.dgvListadoEEFF.Size = new System.Drawing.Size(879, 380);
            this.dgvListadoEEFF.TabIndex = 248;
            this.dgvListadoEEFF.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoEEFF_CellDoubleClick);
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "ID Empresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmpresaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEEFFDataGridViewTextBoxColumn
            // 
            this.idEEFFDataGridViewTextBoxColumn.DataPropertyName = "idEEFF";
            this.idEEFFDataGridViewTextBoxColumn.HeaderText = "idEEFF";
            this.idEEFFDataGridViewTextBoxColumn.Name = "idEEFFDataGridViewTextBoxColumn";
            this.idEEFFDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEEFFDataGridViewTextBoxColumn.Visible = false;
            // 
            // tipoSeccionDataGridViewTextBoxColumn
            // 
            this.tipoSeccionDataGridViewTextBoxColumn.DataPropertyName = "TipoSeccion";
            this.tipoSeccionDataGridViewTextBoxColumn.HeaderText = "Tipo Seccion";
            this.tipoSeccionDataGridViewTextBoxColumn.Name = "tipoSeccionDataGridViewTextBoxColumn";
            this.tipoSeccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoSeccionDataGridViewTextBoxColumn.Width = 95;
            // 
            // desSeccionDataGridViewTextBoxColumn
            // 
            this.desSeccionDataGridViewTextBoxColumn.DataPropertyName = "desSeccion";
            this.desSeccionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desSeccionDataGridViewTextBoxColumn.Name = "desSeccionDataGridViewTextBoxColumn";
            this.desSeccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.desSeccionDataGridViewTextBoxColumn.Width = 320;
            // 
            // tipoReporteDataGridViewTextBoxColumn
            // 
            this.tipoReporteDataGridViewTextBoxColumn.DataPropertyName = "tipoReporte";
            this.tipoReporteDataGridViewTextBoxColumn.HeaderText = "Tipo Reporte";
            this.tipoReporteDataGridViewTextBoxColumn.Name = "tipoReporteDataGridViewTextBoxColumn";
            this.tipoReporteDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoReporteDataGridViewTextBoxColumn.Visible = false;
            // 
            // indComparativoDataGridViewTextBoxColumn
            // 
            this.indComparativoDataGridViewTextBoxColumn.DataPropertyName = "indComparativo";
            this.indComparativoDataGridViewTextBoxColumn.HeaderText = "Comparativo";
            this.indComparativoDataGridViewTextBoxColumn.Name = "indComparativoDataGridViewTextBoxColumn";
            this.indComparativoDataGridViewTextBoxColumn.ReadOnly = true;
            this.indComparativoDataGridViewTextBoxColumn.Visible = false;
            // 
            // indcCostosDataGridViewTextBoxColumn
            // 
            this.indcCostosDataGridViewTextBoxColumn.DataPropertyName = "indcCostos";
            this.indcCostosDataGridViewTextBoxColumn.HeaderText = "C. Costos";
            this.indcCostosDataGridViewTextBoxColumn.Name = "indcCostosDataGridViewTextBoxColumn";
            this.indcCostosDataGridViewTextBoxColumn.ReadOnly = true;
            this.indcCostosDataGridViewTextBoxColumn.Visible = false;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            this.UsuarioRegistro.HeaderText = "Usuario Reg.";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            this.FechaRegistro.HeaderText = "Fecha Reg.";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Width = 120;
            // 
            // UsuarioModificacion
            // 
            this.UsuarioModificacion.DataPropertyName = "UsuarioModificacion";
            this.UsuarioModificacion.HeaderText = "Usuario Mod.";
            this.UsuarioModificacion.Name = "UsuarioModificacion";
            this.UsuarioModificacion.ReadOnly = true;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            this.FechaModificacion.HeaderText = "Fecha Mod.";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            this.FechaModificacion.Width = 120;
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
            // frmListadoEEFF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 412);
            this.Controls.Add(this.panel5);
            this.MaximizeBox = false;
            this.Name = "frmListadoEEFF";
            this.Text = "Listado de Estados Financieros";
            this.Load += new System.EventHandler(this.frmListadoEEFF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFF)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoEEFF;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsEEFF;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoSeccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desSeccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indComparativoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoReporteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indcCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
    }
}