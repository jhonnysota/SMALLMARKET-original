namespace ClienteWinForm.Ventas.OT
{
    partial class frmListadoOrdenTrabajoServicio
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkAreas = new System.Windows.Forms.CheckBox();
            this.cboAreas = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvOrdenTrabajoServicio = new System.Windows.Forms.DataGridView();
            this.cmsOrdenPago = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mandarPorCorreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.bsOrdenTrabajoServicio = new System.Windows.Forms.BindingSource(this.components);
            this.idOTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroOTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenTrabajoServicio)).BeginInit();
            this.cmsOrdenPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenTrabajoServicio)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkAreas);
            this.panel3.Controls.Add(this.cboAreas);
            this.panel3.Controls.Add(this.labelDegradado1);
            this.panel3.Location = new System.Drawing.Point(3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 64);
            this.panel3.TabIndex = 275;
            // 
            // chkAreas
            // 
            this.chkAreas.AutoSize = true;
            this.chkAreas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAreas.Location = new System.Drawing.Point(24, 35);
            this.chkAreas.Name = "chkAreas";
            this.chkAreas.Size = new System.Drawing.Size(102, 17);
            this.chkAreas.TabIndex = 525;
            this.chkAreas.Text = "Todos las Areas";
            this.chkAreas.UseVisualStyleBackColor = true;
            this.chkAreas.CheckedChanged += new System.EventHandler(this.chkAreas_CheckedChanged);
            // 
            // cboAreas
            // 
            this.cboAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAreas.FormattingEnabled = true;
            this.cboAreas.Location = new System.Drawing.Point(147, 33);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Size = new System.Drawing.Size(148, 21);
            this.cboAreas.TabIndex = 310;
            this.cboAreas.SelectionChangeCommitted += new System.EventHandler(this.cboAreas_SelectionChangeCommitted);
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(306, 21);
            this.labelDegradado1.TabIndex = 269;
            this.labelDegradado1.Text = "Área de Trabajo";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvOrdenTrabajoServicio);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 315);
            this.panel1.TabIndex = 79;
            // 
            // dgvOrdenTrabajoServicio
            // 
            this.dgvOrdenTrabajoServicio.AllowUserToAddRows = false;
            this.dgvOrdenTrabajoServicio.AllowUserToDeleteRows = false;
            this.dgvOrdenTrabajoServicio.AutoGenerateColumns = false;
            this.dgvOrdenTrabajoServicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdenTrabajoServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenTrabajoServicio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOTDataGridViewTextBoxColumn,
            this.desArea,
            this.FechaEmision,
            this.numeroOTDataGridViewTextBoxColumn,
            this.RUC,
            this.RazonSocial,
            this.estadoDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvOrdenTrabajoServicio.ContextMenuStrip = this.cmsOrdenPago;
            this.dgvOrdenTrabajoServicio.DataSource = this.bsOrdenTrabajoServicio;
            this.dgvOrdenTrabajoServicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenTrabajoServicio.EnableHeadersVisualStyles = false;
            this.dgvOrdenTrabajoServicio.Location = new System.Drawing.Point(0, 18);
            this.dgvOrdenTrabajoServicio.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOrdenTrabajoServicio.Name = "dgvOrdenTrabajoServicio";
            this.dgvOrdenTrabajoServicio.ReadOnly = true;
            this.dgvOrdenTrabajoServicio.RowTemplate.Height = 24;
            this.dgvOrdenTrabajoServicio.Size = new System.Drawing.Size(802, 295);
            this.dgvOrdenTrabajoServicio.TabIndex = 80;
            this.dgvOrdenTrabajoServicio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenTrabajoServicio_CellDoubleClick);
            // 
            // cmsOrdenPago
            // 
            this.cmsOrdenPago.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mandarPorCorreoToolStripMenuItem});
            this.cmsOrdenPago.Name = "cmsOrdenPago";
            this.cmsOrdenPago.Size = new System.Drawing.Size(176, 26);
            // 
            // mandarPorCorreoToolStripMenuItem
            // 
            this.mandarPorCorreoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mandarPorCorreoToolStripMenuItem.Image = global::ClienteWinForm.Properties.Resources.Enviar_Correo;
            this.mandarPorCorreoToolStripMenuItem.Name = "mandarPorCorreoToolStripMenuItem";
            this.mandarPorCorreoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.mandarPorCorreoToolStripMenuItem.Text = "Mandar Por Correo";
            this.mandarPorCorreoToolStripMenuItem.Click += new System.EventHandler(this.mandarPorCorreoToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
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
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(802, 18);
            this.lblTitulo.TabIndex = 270;
            this.lblTitulo.Text = "Registros 0";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bsOrdenTrabajoServicio
            // 
            this.bsOrdenTrabajoServicio.DataSource = typeof(Entidades.Ventas.OrdenTrabajoServicioE);
            // 
            // idOTDataGridViewTextBoxColumn
            // 
            this.idOTDataGridViewTextBoxColumn.DataPropertyName = "idOT";
            this.idOTDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idOTDataGridViewTextBoxColumn.Name = "idOTDataGridViewTextBoxColumn";
            this.idOTDataGridViewTextBoxColumn.ReadOnly = true;
            this.idOTDataGridViewTextBoxColumn.Width = 30;
            // 
            // desArea
            // 
            this.desArea.DataPropertyName = "desArea";
            this.desArea.HeaderText = "Area";
            this.desArea.Name = "desArea";
            this.desArea.ReadOnly = true;
            // 
            // FechaEmision
            // 
            this.FechaEmision.DataPropertyName = "FechaEmision";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.FechaEmision.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaEmision.HeaderText = "Fec.Emisión";
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.ReadOnly = true;
            this.FechaEmision.Width = 70;
            // 
            // numeroOTDataGridViewTextBoxColumn
            // 
            this.numeroOTDataGridViewTextBoxColumn.DataPropertyName = "numeroOT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numeroOTDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.numeroOTDataGridViewTextBoxColumn.HeaderText = "Numero OT.";
            this.numeroOTDataGridViewTextBoxColumn.Name = "numeroOTDataGridViewTextBoxColumn";
            this.numeroOTDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroOTDataGridViewTextBoxColumn.Width = 90;
            // 
            // RUC
            // 
            this.RUC.DataPropertyName = "RUC";
            this.RUC.HeaderText = "RUC";
            this.RUC.Name = "RUC";
            this.RUC.ReadOnly = true;
            this.RUC.Width = 80;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 200;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "desEstado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 70;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // frmListadoOrdenTrabajoServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 388);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmListadoOrdenTrabajoServicio";
            this.Text = "Listado Orden Trabajo";
            this.Load += new System.EventHandler(this.frmListadoOrdenTrabajoServicio_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenTrabajoServicio)).EndInit();
            this.cmsOrdenPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenTrabajoServicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvOrdenTrabajoServicio;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.BindingSource bsOrdenTrabajoServicio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkAreas;
        private System.Windows.Forms.ComboBox cboAreas;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.ContextMenuStrip cmsOrdenPago;
        private System.Windows.Forms.ToolStripMenuItem mandarPorCorreoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroOTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUC;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}