namespace ClienteWinForm.Ventas
{
    partial class frmListadoNumControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvControl = new System.Windows.Forms.DataGridView();
            this.idControlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.swNotaCreditoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.regVentaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indCodigoBarrasDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indVisibleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipCondicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsControl = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvControl);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(5, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(697, 360);
            this.panel5.TabIndex = 261;
            // 
            // dgvControl
            // 
            this.dgvControl.AllowUserToAddRows = false;
            this.dgvControl.AllowUserToDeleteRows = false;
            this.dgvControl.AutoGenerateColumns = false;
            this.dgvControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idControlDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.swNotaCreditoDataGridViewCheckBoxColumn,
            this.regVentaDataGridViewCheckBoxColumn,
            this.indCodigoBarrasDataGridViewCheckBoxColumn,
            this.indVisibleDataGridViewCheckBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.idEmpresaDataGridViewTextBoxColumn,
            this.idLocalDataGridViewTextBoxColumn,
            this.idTipCondicionDataGridViewTextBoxColumn});
            this.dgvControl.DataSource = this.bsControl;
            this.dgvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvControl.EnableHeadersVisualStyles = false;
            this.dgvControl.Location = new System.Drawing.Point(0, 18);
            this.dgvControl.Name = "dgvControl";
            this.dgvControl.ReadOnly = true;
            this.dgvControl.Size = new System.Drawing.Size(695, 340);
            this.dgvControl.TabIndex = 250;
            this.dgvControl.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvControl_CellDoubleClick);
            this.dgvControl.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvControl_CellFormatting);
            // 
            // idControlDataGridViewTextBoxColumn
            // 
            this.idControlDataGridViewTextBoxColumn.DataPropertyName = "idControl";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idControlDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idControlDataGridViewTextBoxColumn.Frozen = true;
            this.idControlDataGridViewTextBoxColumn.HeaderText = "Cód";
            this.idControlDataGridViewTextBoxColumn.Name = "idControlDataGridViewTextBoxColumn";
            this.idControlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Frozen = true;
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // swNotaCreditoDataGridViewCheckBoxColumn
            // 
            this.swNotaCreditoDataGridViewCheckBoxColumn.DataPropertyName = "swNotaCredito";
            this.swNotaCreditoDataGridViewCheckBoxColumn.HeaderText = "N.C.";
            this.swNotaCreditoDataGridViewCheckBoxColumn.Name = "swNotaCreditoDataGridViewCheckBoxColumn";
            this.swNotaCreditoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // regVentaDataGridViewCheckBoxColumn
            // 
            this.regVentaDataGridViewCheckBoxColumn.DataPropertyName = "regVenta";
            this.regVentaDataGridViewCheckBoxColumn.HeaderText = "R.V.";
            this.regVentaDataGridViewCheckBoxColumn.Name = "regVentaDataGridViewCheckBoxColumn";
            this.regVentaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.regVentaDataGridViewCheckBoxColumn.ToolTipText = "Incluye en el Registro de Ventas";
            // 
            // indCodigoBarrasDataGridViewCheckBoxColumn
            // 
            this.indCodigoBarrasDataGridViewCheckBoxColumn.DataPropertyName = "indCodigoBarras";
            this.indCodigoBarrasDataGridViewCheckBoxColumn.HeaderText = "C.B.";
            this.indCodigoBarrasDataGridViewCheckBoxColumn.Name = "indCodigoBarrasDataGridViewCheckBoxColumn";
            this.indCodigoBarrasDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indCodigoBarrasDataGridViewCheckBoxColumn.ToolTipText = "Indica código de barras";
            // 
            // indVisibleDataGridViewCheckBoxColumn
            // 
            this.indVisibleDataGridViewCheckBoxColumn.DataPropertyName = "indVisible";
            this.indVisibleDataGridViewCheckBoxColumn.HeaderText = "Vis.";
            this.indVisibleDataGridViewCheckBoxColumn.Name = "indVisibleDataGridViewCheckBoxColumn";
            this.indVisibleDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmpresaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idLocalDataGridViewTextBoxColumn
            // 
            this.idLocalDataGridViewTextBoxColumn.DataPropertyName = "idLocal";
            this.idLocalDataGridViewTextBoxColumn.HeaderText = "idLocal";
            this.idLocalDataGridViewTextBoxColumn.Name = "idLocalDataGridViewTextBoxColumn";
            this.idLocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLocalDataGridViewTextBoxColumn.Visible = false;
            // 
            // idTipCondicionDataGridViewTextBoxColumn
            // 
            this.idTipCondicionDataGridViewTextBoxColumn.DataPropertyName = "idTipCondicion";
            this.idTipCondicionDataGridViewTextBoxColumn.HeaderText = "idTipCondicion";
            this.idTipCondicionDataGridViewTextBoxColumn.Name = "idTipCondicionDataGridViewTextBoxColumn";
            this.idTipCondicionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipCondicionDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsControl
            // 
            this.bsControl.DataSource = typeof(Entidades.Ventas.NumControlE);
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(695, 18);
            this.lblRegistros.TabIndex = 367;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoNumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 367);
            this.Controls.Add(this.panel5);
            this.Name = "frmListadoNumControl";
            this.Text = "Control Inicial de Documentos";
            this.Load += new System.EventHandler(this.frmListadoNumControl_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvControl;
        private System.Windows.Forms.BindingSource bsControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn idControlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn swNotaCreditoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn regVentaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCodigoBarrasDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indVisibleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipCondicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistros;
    }
}