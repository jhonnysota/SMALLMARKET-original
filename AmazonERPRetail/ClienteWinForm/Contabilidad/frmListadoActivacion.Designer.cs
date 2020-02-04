namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoActivacion
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
            this.dgvActivacion = new System.Windows.Forms.DataGridView();
            this.cmsActivacion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGenerar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVerVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.bsActivacion = new System.Windows.Forms.BindingSource(this.components);
            this.idActivacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codActivacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivacion)).BeginInit();
            this.cmsActivacion.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsActivacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActivacion
            // 
            this.dgvActivacion.AllowUserToAddRows = false;
            this.dgvActivacion.AllowUserToDeleteRows = false;
            this.dgvActivacion.AutoGenerateColumns = false;
            this.dgvActivacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idActivacion,
            this.codActivacion,
            this.desCCostosDataGridViewTextBoxColumn,
            this.codCuentaDataGridViewTextBoxColumn,
            this.desCuentaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvActivacion.ContextMenuStrip = this.cmsActivacion;
            this.dgvActivacion.DataSource = this.bsActivacion;
            this.dgvActivacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivacion.EnableHeadersVisualStyles = false;
            this.dgvActivacion.Location = new System.Drawing.Point(0, 20);
            this.dgvActivacion.Name = "dgvActivacion";
            this.dgvActivacion.ReadOnly = true;
            this.dgvActivacion.Size = new System.Drawing.Size(747, 307);
            this.dgvActivacion.TabIndex = 261;
            this.dgvActivacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivacion_CellDoubleClick);
            // 
            // cmsActivacion
            // 
            this.cmsActivacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsActivacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerar,
            this.tsmiVerVoucher});
            this.cmsActivacion.Name = "cmsFactura";
            this.cmsActivacion.Size = new System.Drawing.Size(163, 48);
            // 
            // tsmiGenerar
            // 
            this.tsmiGenerar.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.tsmiGenerar.Name = "tsmiGenerar";
            this.tsmiGenerar.Size = new System.Drawing.Size(162, 22);
            this.tsmiGenerar.Text = "Generar Voucher";
            this.tsmiGenerar.Click += new System.EventHandler(this.tsmiGenerar_Click);
            // 
            // tsmiVerVoucher
            // 
            this.tsmiVerVoucher.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.tsmiVerVoucher.Name = "tsmiVerVoucher";
            this.tsmiVerVoucher.Size = new System.Drawing.Size(162, 22);
            this.tsmiVerVoucher.Text = "Ver Voucher";
            this.tsmiVerVoucher.Click += new System.EventHandler(this.tsmiVerVoucher_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvActivacion);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 329);
            this.panel1.TabIndex = 262;
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
            this.lblRegistros.Size = new System.Drawing.Size(747, 20);
            this.lblRegistros.TabIndex = 261;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bsActivacion
            // 
            this.bsActivacion.DataSource = typeof(Entidades.Contabilidad.ActivacionE);
            this.bsActivacion.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsActivacion_ListChanged);
            // 
            // idActivacion
            // 
            this.idActivacion.DataPropertyName = "idActivacion";
            this.idActivacion.HeaderText = "ID.";
            this.idActivacion.Name = "idActivacion";
            this.idActivacion.ReadOnly = true;
            this.idActivacion.Width = 50;
            // 
            // codActivacion
            // 
            this.codActivacion.DataPropertyName = "codActivacion";
            this.codActivacion.HeaderText = "Código";
            this.codActivacion.Name = "codActivacion";
            this.codActivacion.ReadOnly = true;
            this.codActivacion.Width = 80;
            // 
            // desCCostosDataGridViewTextBoxColumn
            // 
            this.desCCostosDataGridViewTextBoxColumn.DataPropertyName = "desCCostos";
            this.desCCostosDataGridViewTextBoxColumn.HeaderText = "C.Costos";
            this.desCCostosDataGridViewTextBoxColumn.Name = "desCCostosDataGridViewTextBoxColumn";
            this.desCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            this.desCCostosDataGridViewTextBoxColumn.Width = 200;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 70;
            // 
            // desCuentaDataGridViewTextBoxColumn
            // 
            this.desCuentaDataGridViewTextBoxColumn.DataPropertyName = "desCuenta";
            this.desCuentaDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desCuentaDataGridViewTextBoxColumn.Name = "desCuentaDataGridViewTextBoxColumn";
            this.desCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desCuentaDataGridViewTextBoxColumn.Width = 250;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // frmListadoActivacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(758, 337);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmListadoActivacion";
            this.Text = "Listado de Capitalización de Gastos";
            this.Load += new System.EventHandler(this.frmListadoActivacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivacion)).EndInit();
            this.cmsActivacion.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsActivacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvActivacion;
        private System.Windows.Forms.BindingSource bsActivacion;
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.ContextMenuStrip cmsActivacion;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerar;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn idActivacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codActivacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}