namespace ClienteWinForm.Almacen
{
    partial class frmListadoAprobarRequisicion
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRequisiciones = new System.Windows.Forms.DataGridView();
            this.numRequisicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipRequisicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRequeridaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impCostoEstimado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Aprobar = new System.Windows.Forms.ToolStripMenuItem();
            this.bsRequisicion = new System.Windows.Forms.BindingSource(this.components);
            this.RPorAprobar = new System.Windows.Forms.RadioButton();
            this.RAprobados = new System.Windows.Forms.RadioButton();
            this.RAmbos = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisiciones)).BeginInit();
            this.CMD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicion)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtpFinal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpInicio);
            this.panel2.Location = new System.Drawing.Point(3, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 62);
            this.panel2.TabIndex = 268;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvRequisiciones);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 421);
            this.panel1.TabIndex = 267;
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
            this.tipRequisicionDataGridViewTextBoxColumn,
            this.fechaSolicitudDataGridViewTextBoxColumn,
            this.fechaRequeridaDataGridViewTextBoxColumn,
            this.desMonedaDataGridViewTextBoxColumn,
            this.impCostoEstimado,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvRequisiciones.ContextMenuStrip = this.CMD;
            this.dgvRequisiciones.DataSource = this.bsRequisicion;
            this.dgvRequisiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequisiciones.EnableHeadersVisualStyles = false;
            this.dgvRequisiciones.Location = new System.Drawing.Point(0, 18);
            this.dgvRequisiciones.Name = "dgvRequisiciones";
            this.dgvRequisiciones.ReadOnly = true;
            this.dgvRequisiciones.Size = new System.Drawing.Size(735, 401);
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
            // tipRequisicionDataGridViewTextBoxColumn
            // 
            this.tipRequisicionDataGridViewTextBoxColumn.DataPropertyName = "tipRequisicion";
            this.tipRequisicionDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.tipRequisicionDataGridViewTextBoxColumn.Name = "tipRequisicionDataGridViewTextBoxColumn";
            this.tipRequisicionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaSolicitudDataGridViewTextBoxColumn
            // 
            this.fechaSolicitudDataGridViewTextBoxColumn.DataPropertyName = "FechaSolicitud";
            this.fechaSolicitudDataGridViewTextBoxColumn.HeaderText = "FechaSolicitud";
            this.fechaSolicitudDataGridViewTextBoxColumn.Name = "fechaSolicitudDataGridViewTextBoxColumn";
            this.fechaSolicitudDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRequeridaDataGridViewTextBoxColumn
            // 
            this.fechaRequeridaDataGridViewTextBoxColumn.DataPropertyName = "FechaRequerida";
            this.fechaRequeridaDataGridViewTextBoxColumn.HeaderText = "FechaRequerida";
            this.fechaRequeridaDataGridViewTextBoxColumn.Name = "fechaRequeridaDataGridViewTextBoxColumn";
            this.fechaRequeridaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desMonedaDataGridViewTextBoxColumn
            // 
            this.desMonedaDataGridViewTextBoxColumn.DataPropertyName = "DesMoneda";
            this.desMonedaDataGridViewTextBoxColumn.HeaderText = "DesMoneda";
            this.desMonedaDataGridViewTextBoxColumn.Name = "desMonedaDataGridViewTextBoxColumn";
            this.desMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // impCostoEstimado
            // 
            this.impCostoEstimado.DataPropertyName = "impCostoEstimado";
            this.impCostoEstimado.HeaderText = "CostoEstimado";
            this.impCostoEstimado.Name = "impCostoEstimado";
            this.impCostoEstimado.ReadOnly = true;
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
            // CMD
            // 
            this.CMD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aprobar});
            this.CMD.Name = "CMD";
            this.CMD.Size = new System.Drawing.Size(182, 26);
            // 
            // Aprobar
            // 
            this.Aprobar.Image = global::ClienteWinForm.Properties.Resources.Add_Reg;
            this.Aprobar.Name = "Aprobar";
            this.Aprobar.Size = new System.Drawing.Size(181, 22);
            this.Aprobar.Text = "Aprobar Requisicion";
            this.Aprobar.Click += new System.EventHandler(this.Aprobar_Click);
            // 
            // bsRequisicion
            // 
            this.bsRequisicion.DataSource = typeof(Entidades.Almacen.RequisicionE);
            // 
            // RPorAprobar
            // 
            this.RPorAprobar.AutoSize = true;
            this.RPorAprobar.Checked = true;
            this.RPorAprobar.Location = new System.Drawing.Point(3, 30);
            this.RPorAprobar.Name = "RPorAprobar";
            this.RPorAprobar.Size = new System.Drawing.Size(81, 17);
            this.RPorAprobar.TabIndex = 269;
            this.RPorAprobar.TabStop = true;
            this.RPorAprobar.Text = "Por Aprobar";
            this.RPorAprobar.UseVisualStyleBackColor = true;
            this.RPorAprobar.CheckedChanged += new System.EventHandler(this.RPorAprobar_CheckedChanged);
            // 
            // RAprobados
            // 
            this.RAprobados.AutoSize = true;
            this.RAprobados.Location = new System.Drawing.Point(104, 30);
            this.RAprobados.Name = "RAprobados";
            this.RAprobados.Size = new System.Drawing.Size(76, 17);
            this.RAprobados.TabIndex = 270;
            this.RAprobados.Text = "Aprobados";
            this.RAprobados.UseVisualStyleBackColor = true;
            this.RAprobados.CheckedChanged += new System.EventHandler(this.RAprobados_CheckedChanged);
            // 
            // RAmbos
            // 
            this.RAmbos.AutoSize = true;
            this.RAmbos.Location = new System.Drawing.Point(195, 30);
            this.RAmbos.Name = "RAmbos";
            this.RAmbos.Size = new System.Drawing.Size(57, 17);
            this.RAmbos.TabIndex = 271;
            this.RAmbos.Text = "Ambos";
            this.RAmbos.UseVisualStyleBackColor = true;
            this.RAmbos.CheckedChanged += new System.EventHandler(this.RAmbos_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.RAmbos);
            this.panel3.Controls.Add(this.RPorAprobar);
            this.panel3.Controls.Add(this.RAprobados);
            this.panel3.Location = new System.Drawing.Point(290, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 62);
            this.panel3.TabIndex = 272;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 18);
            this.label3.TabIndex = 1584;
            this.label3.Text = "Opciones";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 18);
            this.label4.TabIndex = 1584;
            this.label4.Text = "Fechas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(735, 18);
            this.lblRegistros.TabIndex = 1584;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoAprobarRequisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 516);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoAprobarRequisicion";
            this.Text = "Listado Aprobacion Requisicion";
            this.Load += new System.EventHandler(this.frmListadoAprobarRequisicion_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisiciones)).EndInit();
            this.CMD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicion)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRequisiciones;
        private System.Windows.Forms.BindingSource bsRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numRequisicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipRequisicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRequeridaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impCostoEstimado;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip CMD;
        private System.Windows.Forms.ToolStripMenuItem Aprobar;
        private System.Windows.Forms.RadioButton RPorAprobar;
        private System.Windows.Forms.RadioButton RAprobados;
        private System.Windows.Forms.RadioButton RAmbos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label label3;
    }
}