namespace ClienteWinForm.Maestros
{
    partial class frmListadoAfectacionIgv
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAfectacion = new System.Windows.Forms.DataGridView();
            this.idAfectacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desAfectacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indIgv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EquivalenciaSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAfectacionIgv = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfectacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAfectacionIgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvAfectacion);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 383);
            this.panel1.TabIndex = 78;
            // 
            // dgvAfectacion
            // 
            this.dgvAfectacion.AllowUserToAddRows = false;
            this.dgvAfectacion.AllowUserToDeleteRows = false;
            this.dgvAfectacion.AutoGenerateColumns = false;
            this.dgvAfectacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAfectacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAfectacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAfectacion,
            this.desAfectacionDataGridViewTextBoxColumn,
            this.indIgv,
            this.EquivalenciaSunat,
            this.indEstado,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvAfectacion.DataSource = this.bsAfectacionIgv;
            this.dgvAfectacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAfectacion.EnableHeadersVisualStyles = false;
            this.dgvAfectacion.Location = new System.Drawing.Point(0, 18);
            this.dgvAfectacion.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAfectacion.Name = "dgvAfectacion";
            this.dgvAfectacion.ReadOnly = true;
            this.dgvAfectacion.RowTemplate.Height = 24;
            this.dgvAfectacion.Size = new System.Drawing.Size(985, 363);
            this.dgvAfectacion.TabIndex = 80;
            this.dgvAfectacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCapellada_CellDoubleClick);
            this.dgvAfectacion.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAfectacion_CellFormatting);
            // 
            // idAfectacion
            // 
            this.idAfectacion.DataPropertyName = "idAfectacion";
            this.idAfectacion.HeaderText = "ID";
            this.idAfectacion.Name = "idAfectacion";
            this.idAfectacion.ReadOnly = true;
            this.idAfectacion.Width = 70;
            // 
            // desAfectacionDataGridViewTextBoxColumn
            // 
            this.desAfectacionDataGridViewTextBoxColumn.DataPropertyName = "DesAfectacion";
            this.desAfectacionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desAfectacionDataGridViewTextBoxColumn.Name = "desAfectacionDataGridViewTextBoxColumn";
            this.desAfectacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.desAfectacionDataGridViewTextBoxColumn.Width = 200;
            // 
            // indIgv
            // 
            this.indIgv.DataPropertyName = "indIgv";
            this.indIgv.HeaderText = "Ind. IGV";
            this.indIgv.Name = "indIgv";
            this.indIgv.ReadOnly = true;
            this.indIgv.Width = 60;
            // 
            // EquivalenciaSunat
            // 
            this.EquivalenciaSunat.DataPropertyName = "EquivalenciaSunat";
            this.EquivalenciaSunat.HeaderText = "Equi. Sunat";
            this.EquivalenciaSunat.Name = "EquivalenciaSunat";
            this.EquivalenciaSunat.ReadOnly = true;
            this.EquivalenciaSunat.Width = 87;
            // 
            // indEstado
            // 
            this.indEstado.DataPropertyName = "indEstado";
            this.indEstado.HeaderText = "Ind. Estado";
            this.indEstado.Name = "indEstado";
            this.indEstado.ReadOnly = true;
            this.indEstado.Width = 75;
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
            // bsAfectacionIgv
            // 
            this.bsAfectacionIgv.DataSource = typeof(Entidades.Maestros.AfectacionIgvE);
            this.bsAfectacionIgv.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsAfectacionIgv_ListChanged);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idAfectacion";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DesAfectacion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Afectacion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 190;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn3.HeaderText = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FechaRegistro";
            this.dataGridViewTextBoxColumn4.HeaderText = "FechaRegistro";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn5.HeaderText = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(985, 18);
            this.lblRegistros.TabIndex = 1574;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoAfectacionIgv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 391);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoAfectacionIgv";
            this.Text = "Listado Afectacion Igv";
            this.Load += new System.EventHandler(this.frmListadoAfectacionIgv_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfectacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAfectacionIgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAfectacion;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bsAfectacionIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAfectacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn desAfectacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquivalenciaSunat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistros;
    }
}