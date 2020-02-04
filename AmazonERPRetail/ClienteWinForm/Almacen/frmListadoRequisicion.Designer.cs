namespace ClienteWinForm.Almacen
{
    partial class frmListadoRequisicion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRequisiciones = new System.Windows.Forms.DataGridView();
            this.numRequisicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesTipRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRequeridaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impCostoEstimadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMS1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMandarCorreo = new System.Windows.Forms.ToolStripMenuItem();
            this.bsRequisicion = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.lblLetras = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisiciones)).BeginInit();
            this.CMS1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicion)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvRequisiciones);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 421);
            this.panel1.TabIndex = 251;
            // 
            // dgvRequisiciones
            // 
            this.dgvRequisiciones.AllowUserToAddRows = false;
            this.dgvRequisiciones.AllowUserToDeleteRows = false;
            this.dgvRequisiciones.AutoGenerateColumns = false;
            this.dgvRequisiciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequisiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequisiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numRequisicionDataGridViewTextBoxColumn,
            this.DesTipRequisicion,
            this.fechaSolicitudDataGridViewTextBoxColumn,
            this.fechaRequeridaDataGridViewTextBoxColumn,
            this.DesMoneda,
            this.impCostoEstimadoDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvRequisiciones.ContextMenuStrip = this.CMS1;
            this.dgvRequisiciones.DataSource = this.bsRequisicion;
            this.dgvRequisiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequisiciones.EnableHeadersVisualStyles = false;
            this.dgvRequisiciones.Location = new System.Drawing.Point(0, 18);
            this.dgvRequisiciones.Name = "dgvRequisiciones";
            this.dgvRequisiciones.ReadOnly = true;
            this.dgvRequisiciones.Size = new System.Drawing.Size(792, 401);
            this.dgvRequisiciones.TabIndex = 1;
            this.dgvRequisiciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequisiciones_CellDoubleClick);
            // 
            // numRequisicionDataGridViewTextBoxColumn
            // 
            this.numRequisicionDataGridViewTextBoxColumn.DataPropertyName = "numRequisicion";
            this.numRequisicionDataGridViewTextBoxColumn.HeaderText = "Requisicion";
            this.numRequisicionDataGridViewTextBoxColumn.Name = "numRequisicionDataGridViewTextBoxColumn";
            this.numRequisicionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DesTipRequisicion
            // 
            this.DesTipRequisicion.DataPropertyName = "DesTipRequisicion";
            this.DesTipRequisicion.HeaderText = "Tip. Requisicion";
            this.DesTipRequisicion.Name = "DesTipRequisicion";
            this.DesTipRequisicion.ReadOnly = true;
            this.DesTipRequisicion.Width = 140;
            // 
            // fechaSolicitudDataGridViewTextBoxColumn
            // 
            this.fechaSolicitudDataGridViewTextBoxColumn.DataPropertyName = "FechaSolicitud";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.fechaSolicitudDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaSolicitudDataGridViewTextBoxColumn.HeaderText = "Fecha Sol.";
            this.fechaSolicitudDataGridViewTextBoxColumn.Name = "fechaSolicitudDataGridViewTextBoxColumn";
            this.fechaSolicitudDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaSolicitudDataGridViewTextBoxColumn.Width = 70;
            // 
            // fechaRequeridaDataGridViewTextBoxColumn
            // 
            this.fechaRequeridaDataGridViewTextBoxColumn.DataPropertyName = "FechaRequerida";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.fechaRequeridaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaRequeridaDataGridViewTextBoxColumn.HeaderText = "Fecha Req.";
            this.fechaRequeridaDataGridViewTextBoxColumn.Name = "fechaRequeridaDataGridViewTextBoxColumn";
            this.fechaRequeridaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRequeridaDataGridViewTextBoxColumn.Width = 70;
            // 
            // DesMoneda
            // 
            this.DesMoneda.DataPropertyName = "DesMoneda";
            this.DesMoneda.HeaderText = "Mon.";
            this.DesMoneda.Name = "DesMoneda";
            this.DesMoneda.ReadOnly = true;
            this.DesMoneda.Width = 40;
            // 
            // impCostoEstimadoDataGridViewTextBoxColumn
            // 
            this.impCostoEstimadoDataGridViewTextBoxColumn.DataPropertyName = "impCostoEstimado";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.impCostoEstimadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.impCostoEstimadoDataGridViewTextBoxColumn.HeaderText = "Costo Estim.";
            this.impCostoEstimadoDataGridViewTextBoxColumn.Name = "impCostoEstimadoDataGridViewTextBoxColumn";
            this.impCostoEstimadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.impCostoEstimadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // CMS1
            // 
            this.CMS1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMandarCorreo});
            this.CMS1.Name = "CMS1";
            this.CMS1.Size = new System.Drawing.Size(176, 26);
            // 
            // tsmiMandarCorreo
            // 
            this.tsmiMandarCorreo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiMandarCorreo.Image = global::ClienteWinForm.Properties.Resources.Enviar_Correo;
            this.tsmiMandarCorreo.Name = "tsmiMandarCorreo";
            this.tsmiMandarCorreo.Size = new System.Drawing.Size(175, 22);
            this.tsmiMandarCorreo.Text = "Mandar Por Correo";
            this.tsmiMandarCorreo.Click += new System.EventHandler(this.tsmiMandarCorreo_Click);
            // 
            // bsRequisicion
            // 
            this.bsRequisicion.DataSource = typeof(Entidades.Almacen.RequisicionE);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtpFinal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpInicio);
            this.panel2.Location = new System.Drawing.Point(267, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 62);
            this.panel2.TabIndex = 266;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "De";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(169, 28);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 260;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 261;
            this.label2.Text = "hasta";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(37, 28);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 259;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblLetras);
            this.panel3.Controls.Add(this.cboSucursal);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 62);
            this.panel3.TabIndex = 1001;
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(6, 28);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(241, 21);
            this.cboSucursal.TabIndex = 1001;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(260, 18);
            this.lblLetras.TabIndex = 1580;
            this.lblLetras.Text = "Sucursal";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 18);
            this.label3.TabIndex = 1580;
            this.label3.Text = "Fechas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(792, 18);
            this.lblRegistros.TabIndex = 1580;
            this.lblRegistros.Text = "Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoRequisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 491);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoRequisicion";
            this.Text = "Listado Requisicion";
            this.Load += new System.EventHandler(this.frmListadoRequisicion_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisiciones)).EndInit();
            this.CMS1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicion)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRequisiciones;
        private System.Windows.Forms.BindingSource bsRequisicion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.ContextMenuStrip CMS1;
        private System.Windows.Forms.ToolStripMenuItem tsmiMandarCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numRequisicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesTipRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRequeridaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn impCostoEstimadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLetras;
    }
}